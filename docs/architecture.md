Gateway
========

Why a gateway?
- Bot cannot be created using API
- Bot Framework is implemented only in C# and NodeJS
- Frameworks will evolve and may break the current bot

Goals:
- Create a simple API to any language
- Improve testing and speed up development
- Hide the complexity of handling secrets

Assumption:
- 100% Compatible with current Bot Framework


## API Definition ##

### Gateway ###

`/api/message`: Receive from the Bot Server (auth: bot credential)

`/api/client`: Register the client relay (auth: common_pwd)

`/api/channel`: Receive from the Client (auth: common_pwd)

(Client) `/api/message`: Send the message to the client (auth: common_pwd)

`/api/chats`: Initiate a new conversation in a bidirectional channel (auth: common_pwd)

`/api/chats/{conversation_id}`: Connect to a bidirectional channel (auth: common_pwd)



### Gateway Portal ###

`/portal/init`: Store the Bot Server credentials

`/portal/client`: Register the client relay

`/dxconfig`: Configure the credentials



Bot Function
==============

Multi-tenant architecture: associate a Bot Function (CSX file) to the gateway.

Proposal for Multi-tenant extension:

`GET /api/bots/{bot}/message`: Entry point for Bot Framework

`GET /api/bots/{bot}/client`: Get the registered client

`POST /api/bots/{bot}/client`: Register the client relay

`PUT /api/bots/{bot}/client`: Update the client relay setting

`GET /api/bots/{bot}/channel`: Provide a channel to call back


Bot Function Script
======================

Must run in a ASP.NET Core project
