

proto/mail.proto#com.gzyouai.hummingbird.zw.protobufproto/game.proto"S
CmdListMailReqMsg>
type (20.com.gzyouai.hummingbird.zw.protobuf.MailBoxType"P
CmdListMailRspMsg;
mails (2,.com.gzyouai.hummingbird.zw.protobuf.CmdMail"‹
CmdPushMailBC:
mail (2,.com.gzyouai.hummingbird.zw.protobuf.CmdMail>
type (20.com.gzyouai.hummingbird.zw.protobuf.MailBoxType"N
CmdSendWordMailReqMsg
receiverNames (	
title (	
content (	"*
CmdSendWordMailRspMsg
	errorName (	"e
CmdSetReadReqMsgA
cmdType (20.com.gzyouai.hummingbird.zw.protobuf.MailBoxType
mailId ("(
CmdSetReadRspMsg
receiverTime ("_
CmdDelMailReqMsg
ids (>
type (20.com.gzyouai.hummingbird.zw.protobuf.MailBoxType""
CmdDelMailRspMsg
isSucc ("f
CmdFetchAttachmentReqMsg

id (>
type (20.com.gzyouai.hummingbird.zw.protobuf.MailBoxType"*
CmdFetchAttachmentRspMsg
isSucc ("Ô
CmdMail
mailId (
senderId (

senderName (	

senderTime (

receiverId (
receiverName (	
receiverTime (E
cmdMailType (20.com.gzyouai.hummingbird.zw.protobuf.CmdMailType
title	 (	
content
 (	O
cmdRewardContent (25.com.gzyouai.hummingbird.zw.protobuf.CmdRewardContent
rewardStatus (
rewardStartTime (
rewardEndTime (

pkReportId (	
reportId (	
style (	
lock ("
CmdViewBlacklistReqMsg"Y
CmdViewBlacklistRspMsg?
info (21.com.gzyouai.hummingbird.zw.protobuf.CmdBlackInfo"1
CmdRemoveBlacklistReqMsg
blackPlayerId ("+
CmdRemoveBlacklistRspMsg
success (".
CmdAddBlacklistReqMsg
blackPlayerId ("(
CmdAddBlacklistRspMsg
success ("L
CmdBlackInfo
playerId (
name (	
level (
image (	"V
CmdSendWordMailByPlayerIdReqMsg
toPlayerIds (
title (	
content (	"2
CmdSendWordMailByPlayerIdRspMsg
success ("B
CmdViewMailReportReqMsg
reportId (	

reportType (:0"-
CmdViewMailReportRspMsg

reportData (	"S
CmdAutoMailReqMsg>
type (20.com.gzyouai.hummingbird.zw.protobuf.MailBoxType"$
CmdAutoMailRspMsg
success ("e
CmdSetLockReqMsgA
cmdType (20.com.gzyouai.hummingbird.zw.protobuf.MailBoxType
mailId (" 
CmdSetLockRspMsg
lock (*Ñ
MailBoxType
In
Out
report_zhengcha
GM
ArenaReport
ServerArenaReport
report_world_quest_atk
report_world_quest_def
BusinessAtk	
BusinessDef

BusinessDetect*Ë
CmdMailType
Personal
Sys
Sos
ArenaPkReport
PkReport
	SpyReport
MapTaskReport
BusinessAtkReport	
BusinessDefReport

BusinessDetectReport
GmO	
CaiJiP