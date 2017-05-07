using Hummingbird.SeaBattle.Utility.Platform;
using LuaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AppView : View
{
	private Text txtVersion;

	private Slider sliderExtractProgress;

	private Text txtCheckUpdateTips;

	private Transform transUpgradeTips;

	private RectTransform rectTransContent;

	private Text txtUpdateTips;

	private Action updateCallback;

	private List<string> MessageList
	{
		get
		{
			return new List<string>
			{
				"UpdateTipsContent",
				"ExtractPackageFile",
				"UpdateDownloadProgress",
				"UpdateCompleteEnterGame",
				"UpdateShowTips"
			};
		}
	}

	private void Awake()
	{
		this.InitView();
		base.RemoveMessage(this, this.MessageList);
		base.RegisterMessage(this, this.MessageList);
	}

	private void OnDestroy()
	{
		base.RemoveMessage(this, this.MessageList);
		this.txtCheckUpdateTips.transform.parent.gameObject.SetActive(false);
		this.sliderExtractProgress.gameObject.SetActive(false);
	}

	private void InitView()
	{
		Util.ReadGameVersionInfo();
		Transform transform = base.transform.FindChild("SliderExtract");
		this.sliderExtractProgress = transform.GetComponent<Slider>();
		this.txtVersion = base.transform.FindChild("TxtVersion").GetComponent<Text>();
		this.txtVersion.text = string.Format("{0}_{1}_{2}", PlatformUtil.GetInstance().GetChannelId(), AppConst.GameVerName, AppConst.GameVerCode);
		this.txtCheckUpdateTips = base.transform.FindChild("ImgTips/TxtCheckTips").GetComponent<Text>();
		this.txtCheckUpdateTips.text = Util.GetDesConfig("requestGameConfigIng");
		this.transUpgradeTips = base.transform.FindChild("ObjUpgradeTips");
		this.rectTransContent = this.transUpgradeTips.FindChild("ScrollView/Viewport/Content").GetComponent<RectTransform>();
		this.txtUpdateTips = this.transUpgradeTips.FindChild("ScrollView/Viewport/Content/Text").GetComponent<Text>();
		Button component = this.transUpgradeTips.FindChild("Button").GetComponent<Button>();
		component.onClick.RemoveAllListeners();
		component.onClick.AddListener(new UnityAction(this.OnBtnClickUpdate));
		Text component2 = base.transform.FindChild("ObjTips/TxtWarn").GetComponent<Text>();
		component2.text = Util.GetDesConfig("txtWarn");
		Text component3 = base.transform.FindChild("ObjTips/TxtInformation").GetComponent<Text>();
		component3.text = Util.GetDesConfig("txtInformation");
	}

	public override void OnMessage(IMessage message)
	{
		string name = message.Name;
		object body = message.Body;
		string text = name;
		switch (text)
		{
		case "UpdateTipsContent":
			this.OnUpdateTipsContent(body.ToString());
			break;
		case "ExtractPackageFile":
			this.OnExtractPackageFile(body.ToString());
			break;
		case "UpdateDownloadProgress":
			this.OnDownloadProgress(body.ToString());
			break;
		case "UpdateCompleteEnterGame":
			if (Convert.ToBoolean(body))
			{
				this.txtVersion.text = string.Format("{0}_{1}_{2}", PlatformUtil.GetInstance().GetChannelId(), AppConst.GameVerName, AppConst.GameVerCode);
			}
			break;
		case "UpdateShowTips":
			this.OnShowUpdateTips(body);
			break;
		}
	}

	private void OnUpdateTipsContent(string content)
	{
		this.txtCheckUpdateTips.text = content;
	}

	private void OnExtractPackageFile(string data)
	{
		this.sliderExtractProgress.gameObject.SetActive(true);
		string[] array = data.Split(new char[]
		{
			'|'
		});
		if (array.Length >= 3)
		{
			float num = Util.Float(array[0]);
			this.sliderExtractProgress.value = num / (float)Util.Int(array[1]);
			if (num == -1f)
			{
				this.sliderExtractProgress.value = 1f;
				this.OnUpdateCheck();
			}
		}
		else
		{
			Util.LogError(string.Format("解压文件{0}出现错误!", data));
		}
	}

	private void OnUpdateCheck()
	{
		this.sliderExtractProgress.gameObject.SetActive(false);
		this.sliderExtractProgress.value = 0f;
	}

	private void OnDownloadProgress(string data)
	{
		this.sliderExtractProgress.gameObject.SetActive(true);
		string[] array = data.Split(new char[]
		{
			'|'
		});
		if (array.Length >= 2)
		{
			double num = Convert.ToDouble(array[0]);
			double num2 = Convert.ToDouble(array[1]);
			this.sliderExtractProgress.value = (float)(num / num2);
			this.txtCheckUpdateTips.text = string.Format(Util.GetDesConfig("downloadIng"), num / 2097152.0, num2 / 2097152.0);
		}
	}

	private void OnShowUpdateTips(object data)
	{
		ArrayList arrayList = data as ArrayList;
		this.transUpgradeTips.gameObject.SetActive(true);
		this.txtUpdateTips.text = (arrayList[0] as string);
		this.updateCallback = (arrayList[1] as Action);
		this.rectTransContent.sizeDelta = new Vector2(this.rectTransContent.sizeDelta.x, this.txtUpdateTips.preferredHeight);
	}

	private void OnBtnClickUpdate()
	{
		this.transUpgradeTips.gameObject.SetActive(false);
		if (this.updateCallback != null)
		{
			this.updateCallback();
		}
	}
}
