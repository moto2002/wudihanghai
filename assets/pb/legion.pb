
þ]
proto/legion.proto#com.gzyouai.hummingbird.zw.protobufproto/pk.protoproto/game.proto"‰
CmdCreateLegionReqMsg
name (	
joinType (
	condition (	=
type (2/.com.gzyouai.hummingbird.zw.protobuf.CreateType"_
CmdCreateLegionRspMsgF

legionInfo (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionInfo"Á
CmdLegionInfo

id (
name (	
masterId (

masterName (	
level (
joinType (
joinCondition (	
	noticeOut (	
noticeIn	 (	
rank
 (
num (
score (A
define (21.com.gzyouai.hummingbird.zw.protobuf.CmdDefineJob
	subMaster (
renameTimes ("8
CmdDefineJob
refId (	
name (	
num ("$
CmdLegionListReqMsg
index ("]
CmdLegionListRspMsgF

legionList (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionList"—
CmdLegionList
rank (
legionId (
name (	
level (
num (
power (
isEnemy (
status (
pkId	 ("'
CmdReadLegionReqMsg
legionId ("º
CmdReadLegionRspMsg
name (	

masterName (	
rank (
level (
num (
joinType (
joinCondition (	
notice (	
isApply	 (
power
 ("'
CmdJoinLegionReqMsg
legionId ("(
CmdJoinLegionRspMsg
	isSuceess ("
CmdApplyListReqMsg"Z
CmdApplyListRspMsgD
	applyInfo (21.com.gzyouai.hummingbird.zw.protobuf.CmdApplyInfo"Y
CmdApplyInfo
name (	
level (
power (
vip (
playerId ("v
CmdApplyOpReqMsg>
opType (2..com.gzyouai.hummingbird.zw.protobuf.ApplyType
targetId (
legionId ("h
CmdApplyOpRspMsg
result (D
	applyInfo (21.com.gzyouai.hummingbird.zw.protobuf.CmdApplyInfo"
CmdMemberListReqMsg"]
CmdMemberListRspMsgF

memberInfo (22.com.gzyouai.hummingbird.zw.protobuf.CmdMemberInfo"†
CmdMemberInfo
rank (
playerId (
name (	;
job (2..com.gzyouai.hummingbird.zw.protobuf.LegionJob
define (	
level (
power (
vip (
image	 (	@
ableInfo
 (2..com.gzyouai.hummingbird.zw.protobuf.TableInfo"2
	TableInfo
hasGetTableNum (
refId (	")
CmdMemberDetailReqMsg
playerId ("[
CmdMemberDetailRspMsgB
info (24.com.gzyouai.hummingbird.zw.protobuf.CmdMemberDetail"
CmdMemberDetail
rank (
playerId (
name (	;
job (2..com.gzyouai.hummingbird.zw.protobuf.LegionJob
define (	
level (
power (
vip (
score	 (
gender
 (
offTime (
imageId (	
	pendantId (	
isFriend ("$
CmdQueryLegionReqMsg
name (	"X
CmdQueryLegionRspMsg@
list (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionList"X
CmdEditDefineReqMsgA
define (21.com.gzyouai.hummingbird.zw.protobuf.CmdDefineJob"(
CmdEditDefineRspMsg
	isSuccess ("¤
CmdEditLegionReqMsg?
editType (2-.com.gzyouai.hummingbird.zw.protobuf.EditType
joinType (
joinCondition (	
	noticeOut (	
noticeIn (	"]
CmdEditLegionRspMsgF

legionInfo (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionInfo"ã
CmdEditJobReqMsg=
jobType (2,.com.gzyouai.hummingbird.zw.protobuf.JobEdit
targetId (;
job (2..com.gzyouai.hummingbird.zw.protobuf.LegionJobA
define (21.com.gzyouai.hummingbird.zw.protobuf.CmdDefineJob"¢
CmdEditJobRspMsgF

legionInfo (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionInfoF

playerIndo (22.com.gzyouai.hummingbird.zw.protobuf.CmdMemberInfo"#
CmdDonateRankReqMsg
type ("W
CmdDonateRankRspMsg@
info (22.com.gzyouai.hummingbird.zw.protobuf.CmdDonateInfo"p
CmdDonateInfo
rank (
name (	
job (	
donate (
contribution (
playerId ("
CmdLegionHomeReqMsg"ë
CmdLegionHomeRspMsgF

legionInfo (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionInfoD
	buildInfo (21.com.gzyouai.hummingbird.zw.protobuf.CmdBuildInfoF

playerIndo (22.com.gzyouai.hummingbird.zw.protobuf.CmdMemberInfo",
CmdBuildInfo
refId (	
level ("%
CmdLegionBuildReqMsg
refId (	"š
CmdLegionBuildRspMsg
contribution (C
donate (23.com.gzyouai.hummingbird.zw.protobuf.CmdLegionCountF
	skillList (23.com.gzyouai.hummingbird.zw.protobuf.CmdLegionSkill
rewardCount (
	shopGoods (	
masterRewardCount (
subMasterRewardCount ("„
CmdLegionCount
	goldCount (
	ironCount (
	leadCount (
titaniumCount (
oilCount (
cryCount ("?
CmdLegionSkill
	skillType (
level (
exp ("'
CmdLegionUpgradeReqMsg
refId (	"4
CmdLegionUpgradeRspMsg
level (
exp ("x
CmdLegionDonateReqMsg
refId (	
	skillType (=
type (2/.com.gzyouai.hummingbird.zw.protobuf.DonateType"Ã
CmdLegionDonateRspMsg
contribution (C
donate (23.com.gzyouai.hummingbird.zw.protobuf.CmdLegionCount
exp (B
skill (23.com.gzyouai.hummingbird.zw.protobuf.CmdLegionSkill"%
CmdLegionRewardReqMsg
type ("e
CmdLegionRewardRspMsg
rewardCount (
masterRewardCount (
subMasterRewardCount ("
CmdLegionActiveReqMsg"¾
CmdLegionActiveRspMsgD
active (24.com.gzyouai.hummingbird.zw.protobuf.CmdLegionActive
level (
exp (C
res (26.com.gzyouai.hummingbird.zw.protobuf.CmdLegionResource"c
CmdLegionActiveC

activeType (2/.com.gzyouai.hummingbird.zw.protobuf.ActiveType
num ("²
CmdLegionResource
iron (
lead (
titanium (
oil (
cry (
ironDay (
leadDay (
titaniumDay (
oilDay	 (
cryDay
 ("
CmdGetActiveReqMsg"Y
CmdGetActiveRspMsgC
res (26.com.gzyouai.hummingbird.zw.protobuf.CmdLegionResource"
CmdActiveRankReqMsg"W
CmdActiveRankRspMsg@
rank (22.com.gzyouai.hummingbird.zw.protobuf.CmdActiveRank"H
CmdActiveRank
rank (
name (	
job (	
active ("5
CmdLegionMessageReqMsg
type (
index ("]
CmdLegionMessageRspMsgC
info (25.com.gzyouai.hummingbird.zw.protobuf.CmdLegionMessage"Ê
CmdLegionMessage>
type (20.com.gzyouai.hummingbird.zw.protobuf.MessageType
playerId (
targetId (

f1 (	

f2 (	

f3 (	

f4 (	
time (	
x	 (	
y
 ("
CmdRarityListReqMsg"{
CmdRarityListRspMsg@
info (22.com.gzyouai.hummingbird.zw.protobuf.CmdRarityInfo
rarityGoods (	
score ("+
CmdRarityInfo
refId (	
num ("^
CmdBuyShopReqMsg;
type (2-.com.gzyouai.hummingbird.zw.protobuf.ShopType
refId (	"‹
CmdBuyShopRspMsg
	shopGoods (	
rarityGoods (	
score (@
info (22.com.gzyouai.hummingbird.zw.protobuf.CmdRarityInfo"&
CmdLegionHelpReqMsg
content (	"
CmdLegionHelpRspMsg"
CmdLegionChapterReqMsg"s
CmdLegionChapterRspMsgJ
chapterInfo (25.com.gzyouai.hummingbird.zw.protobuf.CmdLegionChapter
count ("V
CmdLegionChapter
chapterRefId (	
kill (
star (
hasSocre ("/
CmdLegionInstanceReqMsg
chapterRefId (	"g
CmdLegionInstanceRspMsgL
instanceInfo (26.com.gzyouai.hummingbird.zw.protobuf.CmdLegionInstance"š
CmdLegionInstance
instanceRefId (	
isFinish (
	canReward (I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData"‘
CmdLegionInstanceAtkReqMsg
instanceRefId (	
	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData"Þ
CmdLegionInstanceAtkRspMsgL
instanceInfo (26.com.gzyouai.hummingbird.zw.protobuf.CmdLegionInstance
remainingTimes (E
cmdPkRepork (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkReport
legionScore ("6
CmdLegionInstanceRewardReqMsg
instanceRefId (	"m
CmdLegionInstanceRewardRspMsgL
instanceInfo (26.com.gzyouai.hummingbird.zw.protobuf.CmdLegionInstance"
CmdWarAwardListReqMsg"w
CmdWarAwardListRspMsgM
rewardContents (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
canSend ("t
CmdSendAwardReqMsg
	playerIds (K
sendContents (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"`
CmdSendAwardRspMsgJ
curContents (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"
CmdReadInstanceInfoReqMsg"r
CmdReadInstanceInfoRspMsgD
atkInfo (23.com.gzyouai.hummingbird.zw.protobuf.CmdReadAtkInfo
curTime ("+
CmdReadAtkInfo
name (	
num ("
CmdDisbandLegionReqMsg"
CmdDisbandLegionRspMsg"
CmdFastJoinReqMsg"4
CmdFastJoinRspMsg
	isSuceess (
name (	"
CmdLegionHelpListReqMsg"_
CmdLegionHelpListRspMsgD
helpInfo (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionHelp"Í
CmdLegionHelp
playerId (
name (	
image (	

cityTileId (	
level (
limitNum (
helpNum (
canHelp (
	buildName	 (	
	pendantId
 (	
reduceCd ("A
CmdLegionHelpPlayerReqMsg
playerId (

cityTileId (	"
CmdLegionHelpPlayerRspMsg"/
CmdLegionHelpPleaseReqMsg

cityTileId (	"
CmdLegionHelpPleaseRspMsg"g
CmdPushLegionHelpBC@
info (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionHelp
helper (	"%
CmdLegionRenameReqMsg
name (	",
CmdLegionRenameRspMsg
renameTimes ("
CmdLegionPkListReqMsg"Y
CmdLegionPkListRspMsg@
pkList (20.com.gzyouai.hummingbird.zw.protobuf.CmdLegionPk"ß
CmdLegionPk
legionId (

legionName (	
targetId (

targetName (	
playerId (
job (	
status (
	startTime (
sneer	 (
pkId
 (

playerName (	
	sneerTime ("*
CmdLegionDeclareReqMsg
targetId ("Z
CmdLegionDeclareRspMsg@
pkInfo (20.com.gzyouai.hummingbird.zw.protobuf.CmdLegionPk"8
CmdLegionPkOperateReqMsg
pkId (
opType ("\
CmdLegionPkOperateRspMsg@
pkInfo (20.com.gzyouai.hummingbird.zw.protobuf.CmdLegionPk"4
CmdLegionPkRankReqMsg
index (
pkId ("d
CmdLegionPkRankRspMsg<
rank (2..com.gzyouai.hummingbird.zw.protobuf.CmdPkRank
index (":
	CmdPkRank
score (
playerId (
name (	"H
CmdLegionRankDescReqMsg
pkId (
playerId (
index ("W
CmdLegionRankDescRspMsg<
desc (2..com.gzyouai.hummingbird.zw.protobuf.CmdPkDesc"y
	CmdPkDesc
name (	

targetName (	
index (
result (
res (
reportId (	
time ("
CmdLegionPkHistoryReqMsg"^
CmdLegionPkHistoryRspMsgB
history (21.com.gzyouai.hummingbird.zw.protobuf.CmdPkHistory"ƒ
CmdPkHistory

targetName (	
type (
atkTimes (
defTimes (
sneer (
openTime (
pkId (")
CmdLegionEnemyListReqMsg
index ("t
CmdLegionEnemyListRspMsgF

legionList (22.com.gzyouai.hummingbird.zw.protobuf.CmdLegionList
pageSize ("#
CmdLegionMailReqMsg
pkId ("
CmdLegionMailRspMsg")
CmdLegionRewardFastReqMsg
type ("
CmdLegionRewardFastRspMsg"E
CmdPushLegionDaTingInfoBC
exp (
level (
name (	"|
CmdPushLegionScienceInfoBC
exp (
level (B
skill (23.com.gzyouai.hummingbird.zw.protobuf.CmdLegionSkill"5
CmdPushLegionFuLiInfoBC
exp (
level ("T
CmdLegionPknfoBC@
pkInfo (20.com.gzyouai.hummingbird.zw.protobuf.CmdLegionPk*!
ShopType	
Goods

Rarity*s

ActiveType

Donate
Instance
Shop
Halt	
Fight

Mining
Rob	
Login
Recharge	*J

DonateType
Gold
Iron
Lead
Oil
Titanium
Cry*V
JobEdit
SET_Job
KICK

DEMISE
	PROMOTION	
LEAVE

SET_Define* 
EditType
Edit

Notice*-
	ApplyType

CANCEL	
AGREE	
CLEAR*2
	LegionJob

Common 
	MasterSub

Master*,

CreateType
Use_Gold
Use_Resource*…
MessageType

Kick_m
Demise_m
Leave_m	
Set_m

Join_m
Update_m

Instance_m	
Reward_m
AtkWin_m
	AtkLose_m
AtkOther_Win_m
AtkOther_Lose_m
Be_Atk_m

Garrison_m
	Hundred_m
	
War_m

Thousand_m