
ù!
proto/player.proto#com.gzyouai.hummingbird.zw.protobufproto/game.protoproto/activity.protoproto/troop.protoproto/littleSecretary.protoproto/attackCity.protoproto/mineWar.proto"Œ
CmdRegistReqMsg
gender (
name (	
userType (	
openId (	
sign (	
	timestamp (	

channelKey (	
ver (
imei	 (	
imageId
 (	
roleId (
	mobileKey (	
lastIp (	
mobileModel (	
mobileNumber (	
	channelId (
versionName (	
versionCode (	

systemName (	
systemVersion (	
networkType (	
mac (	

bigChannel (	
smallChannel (	

systemType (
token (	
accessId (	
	secretKey (	"x
CmdRegistRspMsg
	channelId (
fee (
playerId (
	sessionId (	

createTime (
name (	"Ž
CmdLoginReqMsg
netId (	
userType (	
openId (	
sign (	
	timestamp (	

channelKey (	
ver (
imei (	
roleId	 (
lastIp
 (	
	channelId (
mobileModel (	
mobileNumber (	U
cmdLoginType (21.com.gzyouai.hummingbird.zw.protobuf.CmdLoginType:LOGIN_SERVER

systemType (
token (	
accessId (	
	secretKey (	"u
CmdLoginRspMsg
playerId (
	sessionId (	
onlineTimeOneDay (
isRename (

createTime ("
CmdInfoReqMsg"Æ
CmdInfoRspMsg
instEquipRemainCount (
instEquipBuyCount (
instEquipTotalCount (
instFittingRemainCount (
instFittingBuyCount (
instFittingTotalCount (
instArmyRemainCount (
instArmyBuyCount (
instArmyTotalCount	 (
equipWarehouseCap
 (
buyPowerCount (
buyPrestigeCount (

maxBoomVal (
playerId (

serverTime (R
onlineRewardInfo (28.com.gzyouai.hummingbird.zw.protobuf.CmdOnlineRewardInfoA
atkInfos (2/.com.gzyouai.hummingbird.zw.protobuf.CmdAtkInfo

arenaFirst (	O
lsReward (2=.com.gzyouai.hummingbird.zw.protobuf.CmdLittleSecretaryRewardH
acTroop (27.com.gzyouai.hummingbird.zw.protobuf.CmdAttackCityTroop
serverOpenTime (L
mineWarStatus (25.com.gzyouai.hummingbird.zw.protobuf.CmdMineWarStatus"
CmdOhtherLoginBC"/
CmdRenameReqMsg
gender (
name (	"
CmdRenameRspMsg"
CmdTestingReqMsg
cmd (	"
CmdTestingRspMsg"f
CmdPlayerAttrOpsReqMsg?
ops (22.com.gzyouai.hummingbird.zw.protobuf.OperationType
num ("
CmdPlayerAttrOpsRspMsg"
CmdFightPowerQueryReqMsg"m
CmdFightPowerQueryRspMsg
rank (C
growList (21.com.gzyouai.hummingbird.zw.protobuf.CmdFightGrow"-
CmdChangeSignatureReqMsg
	signature (	"
CmdChangeSignatureRspMsg"9
CmdFightGrow
refId (	
rate (
data ("
CmdPlayHotReqMsg"Q
CmdPlayHotRspMsg=
info (2/.com.gzyouai.hummingbird.zw.protobuf.CmdHotInfo":

CmdHotInfo
hotType (
data (
index ("M
CmdPlayHotBC=
info (2/.com.gzyouai.hummingbird.zw.protobuf.CmdHotInfo"+
CmdChangeHeadPhotoReqMsg
imageId (	"
CmdChangeHeadPhotoRspMsg"
CmdGetAllQueueInfoReqMsg"
CmdGetAllQueueInfoRspMsg"–
CmdQueueInfo
type (
cityTile (	
hasQueue (
useQueue (

remainTime (
refId (	
refIds (	
reqTime ("$
CmdSetPendantReqMsg
refId (	"
CmdSetPendantRspMsg"
CmdGetPendantStateReqMsg"5
CmdGetPendantStateRspMsg
specialPendantIds (	"&
CmdClosePushReqMsg
pushType (	"
CmdClosePushRspMsg"
CmdGetGoldProductInfoReqMsg"1
CmdGetGoldProductInfoRspMsg

productIds ("*
CmdGoldProductInfoBC

productIds ("!
CmdRechargeSuccBC
tips (	"a
CmdPlayerReconnectReqMsg

severIndex (
playerId (
	sessionId (	
imei (	"<
CmdPlayerReconnectRspMsg
messages (
result ("o
CmdPlayerSettingReqMsgF
key (29.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerSettingType
value (	"
CmdPlayerSettingRspMsg"
CmdPlayerSharekrReqMsg"
CmdPlayerSharekrRspMsg"
CmdGetServerOpenDayReqMsg"(
CmdGetServerOpenDayRspMsg
day ("9
CmdPlayerTokenReqMsg
token (	

systemType ("
CmdPlayerTokenRspMsg*0
CmdLoginType

PUBLIC_SDK
LOGIN_SERVER*\
OperationType
	Buy_power
Buy_prestige

Up_captain

Up_boomVal

Up_Job*)
CmdPlayerSettingType
friendSetting