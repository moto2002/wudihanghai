
�
proto/instance.proto#com.gzyouai.hummingbird.zw.protobufproto/pk.protoproto/game.proto"
CmdChapterSyncReqMsg"�
CmdChapterSyncRspMsg[
cmdInstanceChapterInfo (2;.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterInfoE
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"�
CmdInstanceChapterInfo
chapterRefId (	

fetch1Star (

fetch2Star (

fetch3Star (
star (
remainExploreTimes (
totalExploreTimes (
buyExploreTimes (
isOpen	 ("-
CmdInstanceSyncReqMsg
chapterRefId (	"|
CmdInstanceSyncRspMsg
chapterRefId (	M
cmdInstanceInfo (24.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceInfo"t
CmdInstanceInfo

star (
atcTimes (
winTimes (
receiveBoxStatus ("�
CmdAttackInstanceReqMsg

	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
onHook (:false
	itemTimes ("�
CmdAttackInstanceRspMsgE
cmdPkRepork (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkReport
pkStar (
plusStar (

chapterRefId (	
remainingTimes (

stopOnHook (

receiveBoxStatus	 ("B
CmdFetchChapAwardReqMsg
chapterRefId (	
	starLevel ("
CmdFetchChapAwardRspMsg"&
CmdExchangeItemReqMsg
refId (	"
CmdExchangeItemRspMsg"<
$CmdGetInstanceChapterTopRecordReqMsg
chapterRefId (	"y
$CmdGetInstanceChapterTopRecordRspMsgQ
records (2@.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterTopRecord"�
CmdInstanceChapterTopRecord

playerName (	

recordTime (

pkReportId (	R

recordType (2>.com.gzyouai.hummingbird.zw.protobuf.InstanceChapterRecordType"C
CmdSweepInstanceReqMsg


sweepTimes ("�
CmdSweepInstanceRspMsg

chapterRefId (	M

rewardList (29.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentList
remainingTimes ("]
CmdRewardContentListE
reward (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"1
CmdInstanceBuyTimesReqMsg
chapterRefId (	"u
CmdInstanceBuyTimesRspMsgX
instanceChapterInfo (2;.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterInfo"�
CmdChangeInstanceChapterBCY
instanceChapterInfos (2;.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterInfoE
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"�
%CmdAttkInstanceExtremeAdventureReqMsg

	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData"�
%CmdAttkInstanceExtremeAdventureRspMsgE
cmdPkRepork (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkReport

chapterRefId (	E
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"
CmdResetExtremeReqMsg"^
CmdResetExtremeRspMsgE
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"�
ExtremeInfo
curRefId (	
	passRefid (	

resetCount (



remainSweepingTimeMS ("
CmdSweepingExtremeReqMsg"�
CmdSweepingExtremeRspMsgM

rewardList (29.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentListE
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"*
CmdExtremeTopReportReqMsg
refId (	"l
CmdExtremeTopReportRspMsgO
extremeTopReport (25.com.gzyouai.hummingbird.zw.protobuf.ExtremeTopReport"[
ExtremeTopReport

playerName (	
level (
passTime (	

pkReportId (	"0
CmdFirstEnterInstanceReqMsg
	chapterId (	"
CmdFirstEnterInstanceRspMsg"4
CmdReceiveInstanceBoxReqMsg

CmdReceiveInstanceBoxRspMsgM
cmdInstanceInfo (24.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceInfo*Q
InstanceChapterRecordType	
FIRST
	MIN_POWER
MIN_LOSS
LAST_ATK