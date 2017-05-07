
­&
proto/troop.proto#com.gzyouai.hummingbird.zw.protobufproto/game.protoproto/pk.proto"
CmdTankBagSyncReqMsg"™
CmdTankBagSyncRspMsg>
cmdTanks (2,.com.gzyouai.hummingbird.zw.protobuf.CmdTankA
brokenTanks (2,.com.gzyouai.hummingbird.zw.protobuf.CmdTank")
CmdTank
	tankRefId (	
num ("S
CmdTankProductOpsReqMsg

op (

cityTileId (	
arg (	
num ("x
CmdTankProductOpsRspMsg
isFirst (L
curTankProducts (23.com.gzyouai.hummingbird.zw.protobuf.CmdTankProduct".
CmdTankProductSyncReqMsg

cityTileId (	"g
CmdTankProductSyncRspMsgK
cmdTankProduct (23.com.gzyouai.hummingbird.zw.protobuf.CmdTankProduct"ˆ
CmdTankProduct

id (	
	tankRefId (	
num (

cityTileId (	
remainingTime (
isWait (
reqTime ("?
CmdGetTankInfoReqMsg
	tankRefId (	
viewPlayerId ("€
CmdGetTankInfoRspMsg
	tankRefId (	
aatk (	
acr (	
adr (	
ador (	
ahr (	
awreck (	
adefend (	
acrack	 (	
	atenacity
 (	
abaseatk (

abasemaxhp (
aload (	
amhp (	
pow (	"V
CmdTankProductCompleteSyncBC
	tankRefId (	
queueId (	

cityTileId (	"h
CmdTankProductChangeBCN
changeTankProduct (23.com.gzyouai.hummingbird.zw.protobuf.CmdTankProduct"Ú
CmdTankExecMapTaskReqMsg	
x (	
y (
	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData

forceFight (:false
reponsePlayerId (
tripNow (:false"
CmdTankExecMapTaskRspMsg"
CmdTankMapTaskInfoReqMsg"e
CmdTankMapTaskInfoRspMsgI
mapTaskDatas (23.com.gzyouai.hummingbird.zw.protobuf.CmdMapTaskData"×
CmdMapTaskData

id (	
x (	
y (I
mapTaskStatus (22.com.gzyouai.hummingbird.zw.protobuf.MapTaskStatusE
mapTaskType (20.com.gzyouai.hummingbird.zw.protobuf.MapTaskType
remainingTime (
reqTime (
load (
campLvl	 (
campName
 (	
	tankTypes (
refId (	
miningGroupExp ("º
CmdTankMapTaskDataChangeBC

id (F
ops (29.com.gzyouai.hummingbird.zw.protobuf.MapTaskDataChangeOpsH
mapTaskData (23.com.gzyouai.hummingbird.zw.protobuf.CmdMapTaskData")
CmdTankMapTaskSpeedUpReqMsg

id ("
CmdTankMapTaskSpeedUpRspMsg"'
CmdPkMineReturnTripReqMsg

id ("
CmdPkMineReturnTripRspMsg",
CmdTankMapTaskMatrixInfoReqMsg

id ("¡
CmdTankMapTaskMatrixInfoRspMsg
	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
pow (
generalRefId (	"q
CmdTankRepairReqMsg
refId (	K
tankRepairType (23.com.gzyouai.hummingbird.zw.protobuf.TankRepairType"
CmdTankRepairRspMsg"K
CmdTankDetectCampReqMsg	
x (	
y (
forceDetect (:false"=
CmdTankDetectCampRspMsg

detectData (	
isCode ("7
CmdTankGetMarchingReqTimeReqMsg	
x (	
y (":
CmdTankGetMarchingReqTimeRspMsg
marchingReqTime ("
CmdGetLegionGarrisonsReqMsg"h
CmdGetLegionGarrisonsRspMsgI
infos (2:.com.gzyouai.hummingbird.zw.protobuf.CmdLegionGarrisonInfo"^
CmdLegionGarrisonInfo

id (
name (	
isDef (
image (	
level ("%
CmdSetDefGarrisonReqMsg

id ("
CmdSetDefGarrisonRspMsg"%
CmdGarrisonRecallReqMsg

id ("
CmdGarrisonRecallRspMsg")
CmdGarrisonRepatriateReqMsg

id ("
CmdGarrisonRepatriateRspMsg"
CmdGetAtkListReqMsg"X
CmdGetAtkListRspMsgA
atkInfos (2/.com.gzyouai.hummingbird.zw.protobuf.CmdAtkInfo"‡

CmdAtkInfo

id (
name (	
level (
imageId (		
x (	
y (
remainingTime (

targetName (	"f
CmdAtkInfoSyncBC
addOrDel (@
atkInfo (2/.com.gzyouai.hummingbird.zw.protobuf.CmdAtkInfo"r
CmdLegionGarrisonsBC
addOrDel (H
info (2:.com.gzyouai.hummingbird.zw.protobuf.CmdLegionGarrisonInfo"-
CmdDetectDrawCodeRewardReqMsg
code (	"-
CmdDetectDrawCodeRewardRspMsg
code (	"
CmdDetectRefreshCodeReqMsg"*
CmdDetectRefreshCodeRspMsg
code (	"¤
CmdQueryCampMatrixReqMsg	
x (	
y (
	generalId (	
generalRefId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData",
CmdQueryCampMatrixRspMsg
isChange ("
CmdQueryDeadTankGroupReqMsg"
CmdQueryDeadTankGroupRspMsgE
groups (25.com.gzyouai.hummingbird.zw.protobuf.CmdDeadTankGroup
remainRefreshTime ("a
CmdDeadTankGroup
time (?
	deadTanks (2,.com.gzyouai.hummingbird.zw.protobuf.CmdTank"7
CmdFixDeadTankReqMsg
time (
	tankRefId (	"
CmdFixDeadTankRspMsg*@
MapTaskType
Raid
Rob

Mining
LegionGarrison*m
MapTaskStatus

CREATE
TRIP
RETURN_TRIP

MINING
MINING_COMPELETE
LEGION_GARRISON*5
MapTaskDataChangeOps
ADD_OR_CHANGE

DELETE*2
TankRepairType
Glod_Repair
Crys_Repair