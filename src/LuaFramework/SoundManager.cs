using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
	public class SoundManager : Manager
	{
		private class IntervalAudio
		{
			public float intervalTime;

			public string audioPath;

			public float sumDeltaTime;

			public int intervalBackTime;
		}

		private AudioListener audioListener;

		private AudioSource bgAudio;

		private AudioSource onlyAudio;

		private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();

		private string keyBackgroundMusic = "oldBgKey ";

		private string keyActionSound = "oldActKey";

		private List<AudioSource> freeAudioList = new List<AudioSource>();

		private List<SoundManager.IntervalAudio> intervalAudioList = new List<SoundManager.IntervalAudio>();

		private GameObject AudioManager;

		private SoundManager.IntervalAudio intervalBackgroundMusic;

		private void Start()
		{
			this.AudioManager = GameObject.Find("AudioManager");
			this.audioListener = this.AudioManager.AddComponent<AudioListener>();
			this.bgAudio = this.AudioManager.AddComponent<AudioSource>();
			this.onlyAudio = this.AudioManager.AddComponent<AudioSource>();
			this.CreateAudio3DTemplater();
		}

		private void Update()
		{
			if (this.CanPlaySoundEffect())
			{
				for (int i = 0; i < this.intervalAudioList.Count; i++)
				{
					SoundManager.IntervalAudio intervalAudio = this.intervalAudioList[i];
					if (this.IsTimeTo(intervalAudio))
					{
						this.Play2DAduio(intervalAudio.audioPath, true);
					}
				}
			}
			if (this.CanPlayBackSound() && this.intervalBackgroundMusic != null && this.IsTimeTo(this.intervalBackgroundMusic))
			{
				if (this.bgAudio.isPlaying)
				{
					this.intervalBackgroundMusic.intervalTime = (float)this.intervalBackgroundMusic.intervalBackTime;
					this.bgAudio.Stop();
				}
				else
				{
					this.PlayBackgroundIntervalPlayAduio(this.intervalBackgroundMusic.audioPath, this.intervalBackgroundMusic.intervalBackTime);
				}
			}
		}

		private void CreateAudio3DTemplater()
		{
			GameObject original = new GameObject();
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			gameObject.name = "Audio3DTemplater";
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.loop = true;
			audioSource.spatialBlend = 1f;
			audioSource.dopplerLevel = 0f;
			audioSource.rolloffMode = AudioRolloffMode.Custom;
			audioSource.maxDistance = 150f;
			audioSource.spread = 180f;
			audioSource.playOnAwake = false;
			gameObject.transform.parent = this.AudioManager.transform;
		}

		private bool IsTimeTo(SoundManager.IntervalAudio intervalAudio)
		{
			intervalAudio.sumDeltaTime += Time.deltaTime;
			if (intervalAudio.sumDeltaTime > intervalAudio.intervalTime)
			{
				intervalAudio.sumDeltaTime = 0f;
				return true;
			}
			return false;
		}

		private void Add(string key, AudioClip value)
		{
			if ((this.sounds.ContainsKey(key) && this.sounds[key] != null) || value == null)
			{
				return;
			}
			this.sounds.Add(key, value);
		}

		private AudioClip Get(string key)
		{
			if (!this.sounds.ContainsKey(key) || this.sounds[key] == null)
			{
				return null;
			}
			return this.sounds[key];
		}

		private void LoadAudioClip(string path, Action<AudioClip> finishCallback)
		{
			AudioClip ac = this.Get(path);
			if (ac == null)
			{
				base.ResManager.LoadAudio(path, delegate(UnityEngine.Object[] audios)
				{
					if (audios != null && audios.Length > 0)
					{
						ac = (audios[0] as AudioClip);
						this.Add(path, ac);
					}
					else
					{
						ac = null;
					}
					if (finishCallback != null)
					{
						finishCallback(ac);
					}
				});
			}
			else if (finishCallback != null)
			{
				finishCallback(ac);
			}
		}

		public void CleanAudioClip()
		{
			if (this.sounds.Count > 0)
			{
				List<string> list = new List<string>();
				Dictionary<string, AudioClip>.Enumerator enumerator = this.sounds.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, AudioClip> current = enumerator.Current;
					string text = current.Key.Replace('/', '_');
					if (text.LastIndexOf('.') != -1)
					{
						text = text.Substring(0, text.LastIndexOf('.'));
					}
					UnityEngine.Object arg_7B_0 = this.bgAudio.clip;
					KeyValuePair<string, AudioClip> current2 = enumerator.Current;
					if (arg_7B_0 != current2.Value)
					{
						List<string> arg_96_0 = list;
						KeyValuePair<string, AudioClip> current3 = enumerator.Current;
						arg_96_0.Add(current3.Key);
						base.ResManager.UnloadAssetBundle(text, true, true);
					}
				}
				for (int i = 0; i < list.Count; i++)
				{
					if (this.sounds.ContainsKey(list[i]) && this.sounds[list[i]] == null)
					{
						this.sounds.Remove(list[i]);
					}
				}
				list.Clear();
			}
			this.onlyAudio.Stop();
			this.onlyAudio.clip = null;
			this.intervalBackgroundMusic = null;
			this.ClearIntervalPlayAduio();
			this.Stop2DAduio();
			Util.ClearMemory();
		}

		public bool CanPlayBackSound()
		{
			bool flag = true;
			if (!string.IsNullOrEmpty(this.keyBackgroundMusic))
			{
				flag = (1 == PlayerPrefs.GetInt(this.keyBackgroundMusic, 1));
			}
			return flag && this.audioListener != null && (this.audioListener.transform.parent == null || this.audioListener.transform.parent.gameObject.activeSelf) && this.audioListener.isActiveAndEnabled;
		}

		public void SetPlayBackSound(bool isOpen)
		{
			PlayerPrefs.SetInt(this.keyBackgroundMusic, (!isOpen) ? 0 : 1);
			PlayerPrefs.Save();
			this.PauseOrResumeBackSound(!isOpen);
		}

		public void SetPlayBackVolume(float volume)
		{
			this.bgAudio.volume = volume;
		}

		public void StopBackSound()
		{
			this.bgAudio.Stop();
			this.intervalBackgroundMusic = null;
		}

		public void PauseOrResumeBackSound(bool isPause)
		{
			if (isPause)
			{
				this.bgAudio.Pause();
				this.bgAudio.enabled = false;
			}
			else if (!isPause && this.CanPlayBackSound())
			{
				if (this.intervalBackgroundMusic != null)
				{
					this.PlayBackgroundIntervalPlayAduio(this.intervalBackgroundMusic.audioPath, this.intervalBackgroundMusic.intervalBackTime);
				}
				else
				{
					this.bgAudio.enabled = true;
					this.bgAudio.Play();
				}
			}
		}

		public bool CanPlaySoundEffect()
		{
			bool flag = true;
			if (!string.IsNullOrEmpty(this.keyActionSound))
			{
				flag = (1 == PlayerPrefs.GetInt(this.keyActionSound, 1));
			}
			return flag && this.audioListener != null && (this.audioListener.transform.parent == null || this.audioListener.transform.parent.gameObject.activeSelf) && this.audioListener.isActiveAndEnabled;
		}

		public void SetPlaySoundEffect(bool isOpen)
		{
			PlayerPrefs.SetInt(this.keyActionSound, (!isOpen) ? 0 : 1);
			PlayerPrefs.Save();
		}

		public void PlayBackSound(string path, bool isLoop)
		{
			this.playBackSound(path, isLoop, null);
		}

		private void playBackSound(string path, bool isLoop, SoundManager.IntervalAudio _intervalBackgroundMusic)
		{
			this.LoadAudioClip(path, delegate(AudioClip ac)
			{
				if (ac != null)
				{
					this.bgAudio.Stop();
					if (!isLoop)
					{
						this.bgAudio.clip = null;
						if (!this.CanPlayBackSound())
						{
							return;
						}
						this.bgAudio.PlayOneShot(ac);
					}
					else
					{
						this.intervalBackgroundMusic = _intervalBackgroundMusic;
						if (this.intervalBackgroundMusic != null)
						{
							this.intervalBackgroundMusic.intervalTime = ac.length;
						}
						this.bgAudio.clip = ac;
						this.bgAudio.loop = true;
						if (!this.CanPlayBackSound())
						{
							this.bgAudio.Play();
							this.bgAudio.Pause();
							this.bgAudio.enabled = false;
						}
						else
						{
							this.bgAudio.enabled = true;
							this.bgAudio.Play();
						}
					}
				}
			});
		}

		public void PlayOnlySound(string path, bool oneShotOrNot)
		{
			this.PlaySound(this.onlyAudio, path, oneShotOrNot);
		}

		public void StopOnlySound()
		{
			this.onlyAudio.Stop();
		}

		public void PlayActionSound(string path, bool oneShotOrNot)
		{
			this.Play2DAduio(path, oneShotOrNot);
		}

		public void PlaySound(AudioSource audio, string path, bool oneShotOrNot)
		{
			this.LoadAudioClip(path, delegate(AudioClip ac)
			{
				if (ac != null && audio != null && audio.enabled)
				{
					if (oneShotOrNot)
					{
						if (!this.CanPlaySoundEffect())
						{
							return;
						}
						audio.Stop();
						audio.clip = null;
						audio.PlayOneShot(ac);
					}
					else
					{
						audio.clip = ac;
						audio.loop = true;
						if (!this.CanPlaySoundEffect() || !audio.enabled)
						{
							return;
						}
						audio.Play();
					}
				}
			});
		}

		private AudioSource AddAudioSource(GameObject obj, string path, bool isLoop)
		{
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			this.PlaySound(audioSource, path, isLoop);
			return audioSource;
		}

		public void PlayBackgroundIntervalPlayAduio(string path, int intervalTime)
		{
			if (this.intervalBackgroundMusic == null)
			{
				this.intervalBackgroundMusic = new SoundManager.IntervalAudio();
			}
			this.intervalBackgroundMusic.audioPath = path;
			this.intervalBackgroundMusic.sumDeltaTime = 0f;
			this.intervalBackgroundMusic.intervalBackTime = intervalTime;
			this.playBackSound(path, true, this.intervalBackgroundMusic);
		}

		public void Play2DIntervalPlayAduio(string path, float min, float max)
		{
			SoundManager.IntervalAudio intervalAudio = new SoundManager.IntervalAudio();
			intervalAudio.audioPath = path;
			this.LoadAudioClip(path, delegate(AudioClip ac)
			{
				intervalAudio.intervalTime = ac.length + UnityEngine.Random.Range(min, max);
				intervalAudio.sumDeltaTime = intervalAudio.intervalTime;
				this.intervalAudioList.Add(intervalAudio);
			});
		}

		public void ClearIntervalPlayAduio()
		{
			this.intervalAudioList.Clear();
		}

		public void Play2DAduio(string path, bool isLoop)
		{
			if (!this.CanPlaySoundEffect())
			{
				return;
			}
			for (int i = 0; i < this.freeAudioList.Count; i++)
			{
				AudioSource audioSource = this.freeAudioList[i];
				if (!audioSource.isPlaying)
				{
					this.PlaySound(audioSource, path, isLoop);
					return;
				}
			}
			this.freeAudioList.Add(this.AddAudioSource(this.AudioManager, path, isLoop));
		}

		public void Stop2DAduio()
		{
			for (int i = 0; i < this.freeAudioList.Count; i++)
			{
				AudioSource audioSource = this.freeAudioList[i];
				audioSource.Stop();
				audioSource.clip = null;
			}
		}

		public void ToEnd2DAduio()
		{
			for (int i = 0; i < this.freeAudioList.Count; i++)
			{
				AudioSource audioSource = this.freeAudioList[i];
				audioSource.loop = false;
			}
		}

		public void OpenOrClose2DAduio(bool isOpen)
		{
			for (int i = 0; i < this.freeAudioList.Count; i++)
			{
				AudioSource audioSource = this.freeAudioList[i];
				audioSource.enabled = isOpen;
			}
		}
	}
}
