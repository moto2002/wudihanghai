
Õ
proto/pk.proto#com.gzyouai.hummingbird.zw.protobufproto/game.proto"#
CmdViewPkReportReqMsg

id (	"[
CmdViewPkReportRspMsgB
pkRepork (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkReport"g
CmdViewTroopReqMsgQ
cmdTankMatrixType (26.com.gzyouai.hummingbird.zw.protobuf.CmdTankMatrixType"ê
CmdViewTroopRspMsgQ
cmdTankMatrixType (26.com.gzyouai.hummingbird.zw.protobuf.CmdTankMatrixType
	generalId (	
generalRefId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
troopFightPower (
bAutoFillUp (:false"„
CmdUpdateTroopReqMsgQ
cmdTankMatrixType (26.com.gzyouai.hummingbird.zw.protobuf.CmdTankMatrixType
	generalId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
bAutoFillUp (:false"@
CmdUpdateTroopRspMsg
success (
troopFightPower ("å
CmdQueryTroopReqMsg
generalRefId (	I
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
	troopType (:0"U
CmdQueryTroopRspMsg
capacity (
troopFightPower (
busCapacity ("
CmdDefaultTroopReqMsg"X
CmdDefaultTroopRspMsg?
info (21.com.gzyouai.hummingbird.zw.protobuf.CmdTroopInfo"É
CmdTroopInfoQ
cmdTankMatrixType (26.com.gzyouai.hummingbird.zw.protobuf.CmdTankMatrixType
	troopName (	
exist ("G
CmdMaxTroopReqMsg
type (
	troopType (:0
teamId ("≤
CmdMaxTroopRspMsgI
	tankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
capacity (
troopFightPower (
generalRefId (	
	generalId (	"|
CmdDefaultNameReqMsg
	troopName (	Q
cmdTankMatrixType (26.com.gzyouai.hummingbird.zw.protobuf.CmdTankMatrixType"&
CmdDefaultNameRspMsg
result ("”

CmdPkReport

id (	
leftWin (
leftFirstHand (D

leftPlayer (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkPlayerE
rightPlayer (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkPlayer
leftGeneralId (	
rightGeneralId (	M
leftTankTeams (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamDataN
rightTankTeams	 (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData?
rounds
 (2/.com.gzyouai.hummingbird.zw.protobuf.CmdPkRoundO
leftPkDeadTanks (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamDataP
rightPkDeadTanks (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamDataQ
leftRealDeadTanks (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamDataR
rightRealDeadTanks (26.com.gzyouai.hummingbird.zw.protobuf.CmdPkTankTeamData
pkTime (I

leftReward (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContentJ
rightReward (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
leftTotalTankCount (
leftPkDeadTankCount (
leftRealDeadTankCount (
leftDodgeCount (
leftCritCount (
rightTotalTankCount (
rightPkDeadTankCount (
rightRealDeadTankCount (
rightDodgeCount (
rightCritCount (
leftGeneralRefId (	
rightGeneralRefId (	
leftPkTankIFAttrType (
rightPkTankIFAttrType ("©
CmdPkPlayer
type (
playerId (
nickname (	
gender (
level (
viplevel (
legionId (

legionName (	
	headImage	 (	"¯
CmdPkTankTeamData
index (
	tankRefId (	
num (
teamHp (
teamAtk (
hitRate (
	dodgeRate (
critRate	 (
defRate
 (
crack (
tenacity (
wreck (
defend (
hurt ("_

CmdPkRound

roundIndex (=
bouts (2..com.gzyouai.hummingbird.zw.protobuf.CmdPkBout"u
	CmdPkBout
	boutIndex (

leftAttack (A
effects (20.com.gzyouai.hummingbird.zw.protobuf.CmdPkEffect"q
CmdPkEffect
atkIndex (
defIndex (

effectType (
hurt (
killed (
died (*í
CmdTankMatrixType
	DEFAULT_1
	DEFAULT_2
	DEFAULT_3
	DEFAULT_4
	DEFAULT_5
	DEFAULT_6	
ARENA
INSTANCE

DEFEND	