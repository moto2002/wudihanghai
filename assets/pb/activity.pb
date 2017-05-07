
öŒ
proto/activity.proto#com.gzyouai.hummingbird.zw.protobufproto/game.protoproto/rank.proto"g
CmdActivityInfoListReqMsgJ
activityType (24.com.gzyouai.hummingbird.zw.protobuf.CmdActivityType"g
CmdActivityInfoListRspMsgJ
activityInfo (24.com.gzyouai.hummingbird.zw.protobuf.CmdActivityInfo"’
CmdTakeAwardReqMsg

activityId (	
	contentId (
type (
other (	
equipIds (

fittingIds (	

generalIds (	"s
CmdTakeAwardRspMsg]
cmdPlayerActivityStatus (2<.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerActivityStatus"ú
CmdPlayerActivityStatus

activityId (	
completeStatus (
canTakeAward (
alreadyTakeAward (N

taskStatus (2:.com.gzyouai.hummingbird.zw.protobuf.CmdActivityTaskStatusZ
activityContentTimes (2<.com.gzyouai.hummingbird.zw.protobuf.CmdActivityContentTimes
isOpen (G
activityKVs (22.com.gzyouai.hummingbird.zw.protobuf.CmdActivityKV";
CmdActivityTaskStatus
	contentId (
process ("+
CmdActivityKV
key (	
value (" 
CmdActivityInfo

activityId (	
name (	
image (	M
cmdActivityType (24.com.gzyouai.hummingbird.zw.protobuf.CmdActivityType
open (
title (	
description (	
openTime (
	closeTime	 (
	startTime
 (
endTime (
awardStartTime (
awardEndTime (P
activityContent (27.com.gzyouai.hummingbird.zw.protobuf.CmdActivityContent
	headTitle (	
order (
curTime (
eventId (	
	eventDesc (	
headTitleDesc (	
tab (
thirdActivityId (	"ú
CmdActivityContent

id (
order (
conTitle (	
description (	
limitTiemes (I

rewardList (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentT
activityCondition (29.com.gzyouai.hummingbird.zw.protobuf.CmdActivityCondition
viewGo (	
tag	 (O
sysRedRewardList
 (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"£
CmdActivityCondition
conditionId
 (
	goodsType (	
goodsId (	
num (
value (
strValue (	
	strValue1 (	
	strValue2	 (	"Â
CmdPlayerInfo
playerId (
name (	
img (	
level (
rewardLevel (
canTakeReward (I

rewardList (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"<
CmdActivityContentTimes
	contentId (
curNum ("$
CmdVerifyCDKeyReqMsg
code (	"
CmdVerifyCDKeyRspMsg"{
 CmdGetPlayerActivityStatusReqMsgJ
activityType (24.com.gzyouai.hummingbird.zw.protobuf.CmdActivityType
tab ("Õ
 CmdGetPlayerActivityStatusRspMsg]
cmdPlayerActivityStatus (2<.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerActivityStatusR
otherActivityHot (28.com.gzyouai.hummingbird.zw.protobuf.CmdOtherActivityHot"9
CmdOtherActivityHot

activityId (	
hotNum ("e
CmdRefreshActivityBCM
cmdActivityType (24.com.gzyouai.hummingbird.zw.protobuf.CmdActivityType"
CmdInvestInfoReqMsg"
CmdInvestInfoRspMsgY
cmdInvestDrawStatusList (28.com.gzyouai.hummingbird.zw.protobuf.CmdInvestDrawStatus
isBuy ("
CmdInvestBuyReqMsg"n
CmdInvestBuyRspMsgX
cmdInvestDrawStatuList (28.com.gzyouai.hummingbird.zw.protobuf.CmdInvestDrawStatus"$
CmdInvestDrawReqMsg
cclvl ("l
CmdInvestDrawRspMsgU
cmdInvestDrawStatus (28.com.gzyouai.hummingbird.zw.protobuf.CmdInvestDrawStatus"8
CmdInvestDrawStatus
cclvl (

drawStatus ("
CmdLevelGiftInfoReqMsg"y
CmdLevelGiftInfoRspMsg_
cmdlevelGiftDrawStatusList (2;.com.gzyouai.hummingbird.zw.protobuf.CmdLevelGiftDrawStatus"'
CmdLevelGiftDrawReqMsg
level ("u
CmdLevelGiftDrawRspMsg[
cmdLevelGiftDrawStatus (2;.com.gzyouai.hummingbird.zw.protobuf.CmdLevelGiftDrawStatus";
CmdLevelGiftDrawStatus
level (

drawStatus ("
CmdLoginGiftInfoReqMsg"â
CmdLoginGiftInfoRspMsg
mode (_
cmdLoginGiftDrawStatusList (2;.com.gzyouai.hummingbird.zw.protobuf.CmdLoginGiftDrawStatus
isDraw (
repairCount (
	totalDraw (
	rewardDay (
period (":
CmdLoginGiftDrawDayReqMsg
day (
isRepair ("
CmdLoginGiftDrawDayRspMsg[
cmdLoginGiftDrawStatus (2;.com.gzyouai.hummingbird.zw.protobuf.CmdLoginGiftDrawStatus
repairCount ("
CmdLoginGiftDrawReqMsg",
CmdLoginGiftDrawRspMsg

drawRefIds ("9
CmdLoginGiftDrawStatus
day (

drawStatus ("
CmdNewPlayerGiftDrawReqMsg"
CmdNewPlayerGiftDrawRspMsg"
CmdGetShowActivityTypeReqMsg"n
CmdGetShowActivityTypeRspMsgN
cmdActivityTypes (24.com.gzyouai.hummingbird.zw.protobuf.CmdActivityType"*
CmdDrawOnlineRewardReqMsg
refId (	"o
CmdDrawOnlineRewardRspMsgR
onlineRewardInfo (28.com.gzyouai.hummingbird.zw.protobuf.CmdOnlineRewardInfo"k
CmdOnlineRewardSyncBCR
onlineRewardInfo (28.com.gzyouai.hummingbird.zw.protobuf.CmdOnlineRewardInfo"E
CmdOnlineRewardInfo
nextOlineReward (	
remainingTime ("H
CmdActivityRankReqMsg

activityId (	
index (
type ("Ò
CmdActivityRankRspMsg
myRank (F
rankInfo (24.com.gzyouai.hummingbird.zw.protobuf.CmdRankDataInfo?
rankType (2-.com.gzyouai.hummingbird.zw.protobuf.RankType
extra (
	pageCount ("
CmdVipExpExpirePopBC"
CmdGetPowerActivityInfoReqMsg"Š
CmdGetPowerActivityInfoRspMsgR

statusList (2>.com.gzyouai.hummingbird.zw.protobuf.CmdGetPowerActivityStatus
reaminingTime (">
CmdGetPowerActivityStatus
refId (

drawStatus ("+
CmdPowerActivityDrawReqMsg
refId ("l
CmdPowerActivityDrawRspMsgN
status (2>.com.gzyouai.hummingbird.zw.protobuf.CmdGetPowerActivityStatus"#
!CmdDrawFirstRerchargeRewardReqMsg"#
!CmdDrawFirstRerchargeRewardRspMsg"
CmdMonthCardInfoReqMsg"_
CmdMonthCardInfoRspMsgE

monthCards (21.com.gzyouai.hummingbird.zw.protobuf.CmdMonthCard"G
CmdMonthCard
refId (	

drawStatus (
remainingDay ("'
CmdMonthCardDrawReqMsg
refId (	"^
CmdMonthCardDrawRspMsgD
	monthCard (21.com.gzyouai.hummingbird.zw.protobuf.CmdMonthCard"[
CmdMonthCardSyncBCE

monthCards (21.com.gzyouai.hummingbird.zw.protobuf.CmdMonthCard"
CmdLifetimePurchaseInfoReqMsg"‡
CmdLifetimePurchaseInfoRspMsgO
statuss (2>.com.gzyouai.hummingbird.zw.protobuf.CmdLifetimePurchaseStatus
remainingTime (":
CmdLifetimePurchaseStatus
refId (	
status ("g
CmdLifetimePurchaseBCN
status (2>.com.gzyouai.hummingbird.zw.protobuf.CmdLifetimePurchaseStatus".
CmdLifetimePurchaseDrawReqMsg
refId (	"o
CmdLifetimePurchaseDrawRspMsgN
status (2>.com.gzyouai.hummingbird.zw.protobuf.CmdLifetimePurchaseStatus"H
CmdDrawLotteryActivityReqMsg
thirdActivityId (	
drawNum ("Û
CmdDrawLotteryActivityRspMsg
remainingFreeTimes (K
result (2;.com.gzyouai.hummingbird.zw.protobuf.CmdLotteryRewardResultR
otherActivityHot (28.com.gzyouai.hummingbird.zw.protobuf.CmdOtherActivityHot";
CmdLotteryRewardResult
rewardId (
gridIds ("7
CmdLotteryActivityInfoReqMsg
thirdActivityId (	"p
CmdLotteryActivityInfoRspMsgP
lotteryActivity (27.com.gzyouai.hummingbird.zw.protobuf.CmdLotteryActivity"Ï
CmdLotteryActivity
thirdActivityId (	
	startTime (
endTime (
order (
remainingFreeTimes (I
lotteryGrids (23.com.gzyouai.hummingbird.zw.protobuf.CmdLotteryGridM
lotteryRewards (25.com.gzyouai.hummingbird.zw.protobuf.CmdLotteryReward
desc (	
drawOnceGold	 (
drawTenGold
 ("y
CmdLotteryGridJ
gridContent (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
tab (
gridId ("Ä
CmdLotteryReward
rewardId (H
	conditons (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentF
rewards (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
type ("%
CmdRedListReqMsg
	channelId ("[
CmdRedListRspMsgG
infoList (25.com.gzyouai.hummingbird.zw.protobuf.CmdRedPacketInfo" 
CmdRedPacketInfo>
sender (2..com.gzyouai.hummingbird.zw.protobuf.CmdPlayer
redId (
msg (	
isOver (

playerList (
data (	"l
	CmdPlayer
playerId (
name (	
img (	
	pendantId (	
level (
vipLevel ("¶
CmdPlayerRedInfo
refId (	
num (
name (	
endTime (C
resInfo (22.com.gzyouai.hummingbird.zw.protobuf.CmdRedResInfo
drawNum (
	channelId ("7
CmdRedResInfo
type (	
min (
max ("G
CmdPlayerRedSendReqMsg
	channelId (
refId (	
msg (	"
CmdPlayerRedSendRspMsg"}
CmdRefreshRedListBC
	channelId (C
info (25.com.gzyouai.hummingbird.zw.protobuf.CmdRedPacketInfo
status ("(
CmdPlayerRedQueryReqMsg
redId ("û
CmdPlayerRedQueryRspMsg
num (
msg (	
name (	
	channelId (>
sender (2..com.gzyouai.hummingbird.zw.protobuf.CmdPlayer
isReward (D
	rewardMsg (21.com.gzyouai.hummingbird.zw.protobuf.CmdRedMessge
redId ("Š
CmdRedMessge
pid (
name (	
mesType (?
resList (2..com.gzyouai.hummingbird.zw.protobuf.CmdRedRes
image (	"&
	CmdRedRes
type (	
num ("L
CmdPlayerRedRewardReqMsg
redId (
type (
hongbaoyuId (	"
CmdPlayerRedRewardRspMsg"
CmdPlayerRedInfoReqMsg"_
CmdPlayerRedInfoRspMsgE
myList (25.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerRedInfo"X
CmdPlayerRedBCF
redInfo (25.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerRedInfo"†
CmdRedMessgeBC
redId (D
	rewardMsg (21.com.gzyouai.hummingbird.zw.protobuf.CmdRedMessge
num (

senderName (	"7
CmdExploreActivityInfoReqMsg
thirdActivityId (	"p
CmdExploreActivityInfoRspMsgP
exploreActivity (27.com.gzyouai.hummingbird.zw.protobuf.CmdExploreActivity"‚
CmdExploreActivity
thirdActivityId (	
drawOnceGold (
drawTenGold (K
exploreGroups (24.com.gzyouai.hummingbird.zw.protobuf.CmdExploreGroup
remainingFreeTimes (
rankRewardStatus (
curScore (
ensureScore ("©
CmdExploreGroup
groupId (
	groupName (	
imageId (	N
exploreGoodsList (24.com.gzyouai.hummingbird.zw.protobuf.CmdExploreGoods
	imageType (	"}
CmdExploreGoods
index (L
rewardContent (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
score ("8
CmdGetExploreRankRewardReqMsg
thirdActivityId (	"k
CmdGetExploreRankRewardRspMsgJ
rewards (29.com.gzyouai.hummingbird.zw.protobuf.CmdExploreRankReward"s
CmdExploreRankReward
title (	L
rewardContent (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"J
CmdDrawExploreActivityReqMsg
	drawTimes (
thirdActivityId (	"ø
CmdDrawExploreActivityRspMsgV
drawRewards (2A.com.gzyouai.hummingbird.zw.protobuf.CmdDrawExploreActivityRewardR
otherActivityHot (28.com.gzyouai.hummingbird.zw.protobuf.CmdOtherActivityHot
remainingFreeTimes (
curScore (">
CmdDrawExploreActivityReward
groupId (
index ("9
CmdDrawExploreRankRewardReqMsg
thirdActivityId (	"Ž
CmdDrawExploreRankRewardRspMsgR
otherActivityHot (28.com.gzyouai.hummingbird.zw.protobuf.CmdOtherActivityHot
rankRewardStatus ("
CmdSevenDayActivityInfoReqMsg"â
CmdSevenDayActivityInfoRspMsgH
infos (29.com.gzyouai.hummingbird.zw.protobuf.CmdSevenDayQuestInfo
remainingTime (
remainingAwardTime (
remainingShowTime (
	unlockDay (
shieldRecharge ("]
CmdSevenDayQuestInfo
refId (	
progress (
totalProgress (
state (",
CmdDrawSevenDayRewardReqMsg
refId (	"f
CmdDrawSevenDayRewardRspMsgG
info (29.com.gzyouai.hummingbird.zw.protobuf.CmdSevenDayQuestInfo"
CmdRefreshSevenDayActivityBC"e
CmdSevenDayQuestInfoSyncBCG
info (29.com.gzyouai.hummingbird.zw.protobuf.CmdSevenDayQuestInfo"
CmdQuestionReqMsg"W
CmdQuestionRspMsgB
info (24.com.gzyouai.hummingbird.zw.protobuf.CmdQuestionInfo"ò
CmdQuestionInfo

questionId (	?
qlist (20.com.gzyouai.hummingbird.zw.protobuf.CmdQuestionI

rewardList (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
	startTime (
endTime (
isJoin (
des (	"I
CmdQuestion

id (
question (	
option (	
type ("e
CmdAnswerReqMsg

questionId (	>
define (2..com.gzyouai.hummingbird.zw.protobuf.CmdAnswer"7
	CmdAnswer

id (
choice (
answer (	"
CmdAnswerRspMsg"*
CmdWarshipInfoReqMsg

activityId (	"¼
CmdWarshipInfoRspMsg

activityId (	
drawOnceGold (
drawTenGold (
remainingFreeTimes (I
exchange (27.com.gzyouai.hummingbird.zw.protobuf.CmdWarshipExchange"D
CmdWarshipExchange
refId (	
needNum (
curNum (";
CmdWarshipRandomReqMsg

activityId (	
count ("Ú
CmdWarshipRandomRspMsg

activityId (	
remainingFreeTimes (I
exchange (27.com.gzyouai.hummingbird.zw.protobuf.CmdWarshipExchangeE
reward (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"=
CmdWarshipExchangeReqMsg

activityId (	
refId (	"y
CmdWarshipExchangeRspMsg

activityId (	I
exchange (27.com.gzyouai.hummingbird.zw.protobuf.CmdWarshipExchange"
CmdEverydayRechargeInfoReqMsg">
CmdEverydayRechargeInfoRspMsg
refId (	
status ("
CmdEverydayRechargeDrawReqMsg"/
CmdEverydayRechargeDrawRspMsg
status ("R
CmdRefreshGiftBC>
giftList (2,.com.gzyouai.hummingbird.zw.protobuf.CmdGift"a
CmdGift
giftId (	
num (
name (	
desc (	
quality (
icon (	"#
CmdOpenGiftReqMsg
giftId (	"S
CmdOpenGiftRspMsg>
giftInfo (2,.com.gzyouai.hummingbird.zw.protobuf.CmdGift"%
CmdLoginDayTotalReqMsg
day ("+
CmdLoginDayTotalRspMsg
	totalDraw ("
CmdSevenLoginInfoReqMsg"k
CmdSevenLoginInfoRspMsgP

statusList (2<.com.gzyouai.hummingbird.zw.protobuf.CmdSevenLoginInfoStatus"&
CmdSevenLoginDrawReqMsg
day ("g
CmdSevenLoginDrawRspMsgL
status (2<.com.gzyouai.hummingbird.zw.protobuf.CmdSevenLoginInfoStatus":
CmdSevenLoginInfoStatus
day (

drawStatus ("
CmdSevenLoginRefreshBC"3
CmdRechargeRebateRandomReqMsg

activityId (	"~
CmdRechargeRebateRandomRspMsg]
cmdPlayerActivityStatus (2<.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerActivityStatus"1
CmdRechargeRebateTakeReqMsg

activityId (	"|
CmdRechargeRebateTakeRspMsg]
cmdPlayerActivityStatus (2<.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerActivityStatus"0
CmdExchangeLimitInfoReqMsg

activityId (	"`
CmdExchangeLimitInfoRspMsgB
info (24.com.gzyouai.hummingbird.zw.protobuf.CmdExchangeInfo"¹
CmdExchangeInfo
	contentId (

limitTimes (
isFree (
refreshGold (L
conditionList (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentE
reward (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentE
curNum (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"M
CmdExchangeBuyReqMsg

activityId (	
	contentId (
opType ("¤
CmdExchangeBuyRspMsgB
info (24.com.gzyouai.hummingbird.zw.protobuf.CmdExchangeInfo
equipIds (

fittingIds (	

generalIds (	
hotNum ("Y
CmdRechargeBoxActivity
rechargeGold (
resetUseGold (
costHammers ("Ÿ
CmdRechargeBoxInfoI
rechargeBoxs (23.com.gzyouai.hummingbird.zw.protobuf.CmdRechargeBox
hammer (
progress (
remainFreeResetTimes ("m
CmdRechargeBoxL
rewardContent (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
index ("2
CmdRechargeBoxActivityReqMsg

activityId (	"´
CmdRechargeBoxActivityRspMsgM
activity (2;.com.gzyouai.hummingbird.zw.protobuf.CmdRechargeBoxActivityE
info (27.com.gzyouai.hummingbird.zw.protobuf.CmdRechargeBoxInfo"/
CmdRechargeBoxResetReqMsg

activityId (	"¶
CmdRechargeBoxResetRspMsgE
info (27.com.gzyouai.hummingbird.zw.protobuf.CmdRechargeBoxInfoR
otherActivityHot (28.com.gzyouai.hummingbird.zw.protobuf.CmdOtherActivityHot"=
CmdRechargeBoxTakeReqMsg

activityId (	
index ("µ
CmdRechargeBoxTakeRspMsgE
info (27.com.gzyouai.hummingbird.zw.protobuf.CmdRechargeBoxInfoR
otherActivityHot (28.com.gzyouai.hummingbird.zw.protobuf.CmdOtherActivityHot"¾
CmdOfflineMakeUp
type (P
rewardContentList (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
useGold (
takeType (

offlineDay (
recoverRate (	"
CmdOfflineMakeUpInfoReqMsg"d
CmdOfflineMakeUpInfoRspMsgF
makeUps (25.com.gzyouai.hummingbird.zw.protobuf.CmdOfflineMakeUp":
CmdOfflineMakeUpTakeReqMsg
type (
isFree ("c
CmdOfflineMakeUpTakeRspMsgE
makeUp (25.com.gzyouai.hummingbird.zw.protobuf.CmdOfflineMakeUp"z
CmdPlayerActivityStatusBC]
cmdPlayerActivityStatus (2<.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerActivityStatus*”
CmdActivityType
FIRST_RECHARGE

LEVEL_GIFT
DAILY_LIMIT_BUY

CD_KEY

LOGIN_GIFT
RECHARGE

KAIFU_GIFT
NEW_PLAYER_GIFT

INVEST	
	EQUIP_ACT

REGISTER_N_HOUR
RANKING_ACT
ONLINE_REWARD
EXCHANGE
THUNDER_PLAN
EQUIP_UPGRADE
FIGTTING
INSTANCE_ACT

DRAW_EQUIP

TANBAO
ACCELERATION
CRAZY_ARENA
DAILY_LIMIT_BUY_ADV
LIFELONG_LIMIT_BUY
CONSUME_FINAL
CONSUME_RANK
RECHARGE_FINAL
RECHARGE_RANK
LEGION_DONATE
LEGION_DONATE_RANK

MINING_ACT
	ACT_POWER 
RECHANGE_SINGLE!

MONTH_CARD"
LOTTERY#
HT_ONLINE_REWARD$
RECHARGE_N_DAY_REWARD%
LEIGON_DONATE_REACH&
	OTHER_ADD'
ATK_INSTANCE(
SPECIAL_DEBRIS_PRO)
EXPLORE+
ALL_PEPLE_RED,
RECHARGE_RED-
QUESTION.
GENERAL_COMBINE/
WARSHIP0
EVERYDAY_RECHARGE1
RECHARGE_REBATE2
EXCHANGE_LIMIT3
VIP_GIFT4
RECHARGE_BOX5
OFFLINP_EMAKEUP6
CONSUME7
DAILY_RUSH_BUY8

LIMIT_GIFT9
TANBAO_RANK: