
ø
proto/instance.proto#com.gzyouai.hummingbird.zw.protobufproto/pk.protoproto/game.proto"
CmdChapterSyncReqMsg"º
CmdChapterSyncRspMsg[
cmdInstanceChapterInfo (2;.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterInfoE
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"Ø
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
instanceRefId (	
star (
atcTimes (
winTimes (
receiveBoxStatus ("¸
CmdAttackInstanceReqMsg
instanceRefId (	
	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
onHook (:false
	itemTimes ("Œ
CmdAttackInstanceRspMsgE
cmdPkRepork (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkReport
pkStar (
plusStar (
instanceRefId (	
chapterRefId (	
remainingTimes (

stopOnHook (
autoRepairCry (
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
records (2@.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterTopRecord"­
CmdInstanceChapterTopRecord

playerName (	

recordTime (

pkReportId (	R

recordType (2>.com.gzyouai.hummingbird.zw.protobuf.InstanceChapterRecordType"C
CmdSweepInstanceReqMsg
instanceRefId (	

sweepTimes ("¬
CmdSweepInstanceRspMsg
instanceRefId (	
chapterRefId (	M

rewardList (29.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentList
remainingTimes ("]
CmdRewardContentListE
reward (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"1
CmdInstanceBuyTimesReqMsg
chapterRefId (	"u
CmdInstanceBuyTimesRspMsgX
instanceChapterInfo (2;.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterInfo"¾
CmdChangeInstanceChapterBCY
instanceChapterInfos (2;.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceChapterInfoE
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"œ
%CmdAttkInstanceExtremeAdventureReqMsg
instanceRefId (	
	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData"â
%CmdAttkInstanceExtremeAdventureRspMsgE
cmdPkRepork (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkReport
instanceRefId (	
chapterRefId (	E
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"
CmdResetExtremeReqMsg"^
CmdResetExtremeRspMsgE
extremeInfo (20.com.gzyouai.hummingbird.zw.protobuf.ExtremeInfo"©
ExtremeInfo
curRefId (	
	passRefid (	

resetCount (
canResetCount (
hasChangeTime (
allChangeTime (
remainSweepingTimeMS ("
CmdSweepingExtremeReqMsg"°
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
instanceRefId (	"l
CmdReceiveInstanceBoxRspMsgM
cmdInstanceInfo (24.com.gzyouai.hummingbird.zw.protobuf.CmdInstanceInfo*Q
InstanceChapterRecordType	
FIRST
	MIN_POWER
MIN_LOSS
LAST_ATK