
ÐI
proto/business.proto#com.gzyouai.hummingbird.zw.protobufproto/game.protoproto/pk.protoproto/troop.proto"¾
CmdBusinessTeam
teamId (N
teamBaseInfo (28.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamBaseI

goodsInfos (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoods
	generalId (	
generalRefId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
load ("ô
CmdBusinessTeamBase
teamId (
playerId (

playerName (	
businessLevel (

legionName (	
beatenTimes (
isSameLegion (
	isProtect (B
path (24.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessPath
showTankRefId	 (	
	robTeamId
 (
robPlayerId (

teamStatus (

stopCityId (	
playerLevel ("»
CmdBusinessPath
pathIds (	
	curPathId (	
curPathStartCityId (	
curPathNeedTime (
curPathRemainingTime (
totalNeedTime (
totalRemainingTime ("T
CmdBusinessGoods
teamId (
goodsId (	
num (

costSilver ("O
CmdBusinessGoodsInventory
goodsId (	
silver (
	inventory ("K
CmdBusinessGoodsSale
goodsId (	
silver (

costSilver ("«
CmdBusinessQuest
questId (	
refId (	
status (
cityId (	
acceptQuestTime (
progress (
totalProgress	 (J
condProgress
 (24.com.gzyouai.hummingbird.zw.protobuf.CmdCondProgressI

rewardList (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent"
CmdCondProgress
condType (
progress (
totalProgress (O
dynamicParams (28.com.gzyouai.hummingbird.zw.protobuf.CmdCondDynamicParam";
CmdCondDynamicParam
paramKey (	

paramValue (	"Ç
CmdBusinessGoodsGraph
refId (	
cityId (	P
points (2@.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoodsSilverPoint
refreshRemainingTime (
reqTime (
canBuy ("B
CmdBusinessGoodsSilverPoint
silver (
refreshTime ("S
CmdBusinessHistory
msgId (	
refId (	
params (	
logTime ("
CmdGetBusinessInfoReqMsg"¦
CmdGetBusinessInfoRspMsgC
teams (24.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamE
quests (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"Y
CmdExecBusinessTeamReqMsg
teamId (
targetCityId (	
isAccel (:false"g
CmdExecBusinessTeamRspMsgJ
businessTeam (24.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeam"‹
CmdMatrixBusinessTeamReqMsg
teamId (
	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData"¸
CmdPlayerSimple
playerId (
level (
fight (
	armyGroup (	

playerName (	
gender (
job (
vipLvl (
image	 (	
boomVal
 (

maxBoomVal (
	pendantId (	
	legionJob (	
groupJob (	
	signature (	

cityBuffId (	
hatred ("k
CmdRealBusinessGoods
cityId (	
goodsId (	
canBuy (
reqTime (
	curSilver ("i
CmdMatrixBusinessTeamRspMsgJ
businessTeam (24.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeam"b
CmdCmdBusinessTeamBCJ
businessTeam (24.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeam"1
CmdViewTargetBusinessTeamReqMsg
teamId ("n
CmdViewTargetBusinessTeamRspMsgK
	teamBases (28.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamBase"K
CmdDetectBusinessTeamReqMsg
targetTeamId (
targetPlayerId ("F
CmdDetectBusinessTeamRspMsg
detectTimes (

detectData (	"3
!CmdViewCityBuyBusinessGoodsReqMsg
cityId (	"¾
!CmdViewCityBuyBusinessGoodsRspMsgW
goodsInventorys (2>.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoodsInventory
refreshRemainingTime ("
silverRefreshRemainingTime ("‚
CmdBuyBusinessGoodsReqMsg
teamId (
cityId (	
goodsId (	
num (
	curSilver (
curInventory ("†
CmdBuyBusinessGoodsRspMsg
isChange (W
goodsInventorys (2>.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoodsInventory"D
"CmdViewCitySaleBusinessGoodsReqMsg
cityId (	
teamId ("™
"CmdViewCitySaleBusinessGoodsRspMsgU
businessGoodsSales (29.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoodsSale
refreshRemainingTime ("m
CmdSaleBusinessGoodsReqMsg
teamId (
cityId (	
goodsId (	
num (
	curSilver ("„
CmdSaleBusinessGoodsRspMsgT
businessGoodsSale (29.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoodsSale
isChange ("M
CmdDiscardBusinessGoodsReqMsg
teamId (
goodsId (	
num ("
CmdDiscardBusinessGoodsRspMsg"
CmdRefreshBusinessQuestReqMsg"o
CmdRefreshBusinessQuestRspMsgN
canAcceptQuests (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"-
CmdDiscardQuestQuestReqMsg
questId (	"|
CmdDiscardQuestQuestRspMsg

delQuestId (	J
changeQuest (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"p
CmdRobBusinessTeamReqMsg
teamId (
targetTeamId (
targetPlayerId (
isAccel (:false"f
CmdRobBusinessTeamRspMsgJ
teamBase (28.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamBase"O
CmdGetBusinessGoodsGraphReqMsg
refId (	
cityId (	
teamId ("Š
CmdGetBusinessGoodsGraphRspMsgJ
graphs (2:.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoodsGraph
refreshRemainingTime ("G
CmdExchangeBusinessTankReqMsg
	tankRefId (	
exchangeNum ("
CmdExchangeBusinessTankRspMsg"
CmdGetBusinessTankBagReqMsg"]
CmdGetBusinessTankBagRspMsg>
cmdTanks (2,.com.gzyouai.hummingbird.zw.protobuf.CmdTank"Y
CmdRobImpactCheckerReqMsg
teamId (
targetTeamId (
targetPlayerId ("‰
CmdRobImpactCheckerRspMsg
status (B
pkRepork (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkReportF
teamBase (24.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamP
targetTeamBase (28.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamBase"N
CmdRobImpactBC
teamId (
targetTeamId (
targetPlayerId ("?
CmdAppectBusinessQuestReqMsg
teamId (
questId (	"d
CmdAppectBusinessQuestRspMsgD
quest (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"/
CmdCommitBusinessQuestReqMsg
questId (	"d
CmdCommitBusinessQuestRspMsgD
quest (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest")
CmdCancelNavigateReqMsg
teamId ("e
CmdCancelNavigateRspMsgJ
teamBase (28.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamBase"
CmdBuyBusinessQuestReqMsg"e
CmdBuyBusinessQuestRspMsgH
	newQuests (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"
CmdBuyRobQuestReqMsg"
CmdBuyRobQuestRspMsg"B
CmdBussinessTeamBaseSyncReqMsg
playerId (
teamId ("l
CmdBussinessTeamBaseSyncRspMsgJ
teamBase (28.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamBase"0
CmdSubmitDeliverLettersReqMsg
questId (	"d
CmdSumitDeliverLettersRspMsgD
quest (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"I
CmdBusinessTeamInfoReqMsg
targetPlayerId (
targetTeamId ("Ÿ
CmdBusinessTeamInfoRspMsgB
info (24.com.gzyouai.hummingbird.zw.protobuf.CmdPlayerSimple
showTankRefId (	
businessLevel (
isFriend ("w
CmdRefreshVisionBC
teamId (Q
changeTeamBases (28.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeamBase"g
CmdChangeBusinessQuestBCK
changeQuests (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"a
CmdPlayerBusinessResetBCE
quests (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest"0
CmdViewCityBusinessQuestReqMsg
cityId (	"g
CmdViewCityBusinessQuestRspMsgE
quests (25.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessQuest",
CmdGetBusinessShopReqMsg
shopType ("…
CmdGetBusinessShopRspMsgK
infos (2<.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessExchangeInfo
remainingRefreshTime ("_
CmdBusinessShopExchangeReqMsg
refId (	
shopType (
num (
allTimes ("}
CmdBusinessShopExchangeRspMsg
isChange (J
info (2<.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessExchangeInfo"P
CmdBusinessExchangeInfo
refId (	
exhangeTimes (
allTimes ("*
CmdBusinessTeamFixBC

fixTeamIds ("
CmdGetSameLegionTeamReqMsg"i
CmdGetSameLegionTeamRspMsgK
businessTeams (24.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessTeam"l
CmdGetDistanceForecastReqMsg
teamId (
targetPlayerId (
targetTeamId (
cityId (	"J
CmdGetDistanceForecastRspMsg
forecastReqTime (
	accelGold (""
 CmdDrawBusinessLoginRewardReqMsg""
 CmdDrawBusinessLoginRewardRspMsg"L
CmdRobFightFailureBC
	atkTeamId (
	defTeamId (
status ("
CmdGetBusinessHistoryReqMsg"p
CmdGetBusinessHistoryRspMsgQ
businessHistorys (27.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessHistory"S
"CmdBusinessGoodsGraphDetailsReqMsg
refId (	
cityId (	
teamId ("Û
"CmdBusinessGoodsGraphDetailsRspMsgI
graph (2:.com.gzyouai.hummingbird.zw.protobuf.CmdBusinessGoodsGraphL
	realGoods (29.com.gzyouai.hummingbird.zw.protobuf.CmdRealBusinessGoods
refreshRemainingTime (",
CmdAccelBusinessTeamReqMsg
teamId ("
CmdAccelBusinessTeamRspMsg""
 CmdAwardBusinessSilverWeekReqMsg""
 CmdAwardBusinessSilverWeekRspMsg