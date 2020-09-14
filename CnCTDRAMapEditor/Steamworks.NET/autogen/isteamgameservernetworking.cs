// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2019 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS


namespace Steamworks
{
    public static class SteamGameServerNetworking {
		/// <summary>
		/// <para>//////////////////////////////////////////////////////////////////////////////////////////</para>
		/// <para> UDP-style (connectionless) networking interface.  These functions send messages using</para>
		/// <para> an API organized around the destination.  Reliable and unreliable messages are supported.</para>
		/// <para> For a more TCP-style interface (meaning you have a connection handle), see the functions below.</para>
		/// <para> Both interface styles can send both reliable and unreliable messages.</para>
		/// <para> Automatically establishes NAT-traversing or Relay server connections</para>
		/// <para> Sends a P2P packet to the specified user</para>
		/// <para> UDP-like, unreliable and a max packet size of 1200 bytes</para>
		/// <para> the first packet send may be delayed as the NAT-traversal code runs</para>
		/// <para> if we can't get through to the user, an error will be posted via the callback P2PSessionConnectFail_t</para>
		/// <para> see EP2PSend enum above for the descriptions of the different ways of sending packets</para>
		/// <para> nChannel is a routing number you can use to help route message to different systems 	- you'll have to call ReadP2PPacket()</para>
		/// <para> with the same channel number in order to retrieve the data on the other end</para>
		/// <para> using different channels to talk to the same user will still use the same underlying p2p connection, saving on resources</para>
		/// </summary>
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_SendP2PPacket(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, pubData, cubData, eP2PSendType, nChannel);
		}

		/// <summary>
		/// <para> returns true if any data is available for read, and the amount of data that will need to be read</para>
		/// </summary>
		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsP2PPacketAvailable(CSteamGameServerAPIContext.GetSteamNetworking(), out pcubMsgSize, nChannel);
		}

		/// <summary>
		/// <para> reads in a packet that has been sent from another user via SendP2PPacket()</para>
		/// <para> returns the size of the message and the steamID of the user who sent it in the last two parameters</para>
		/// <para> if the buffer passed in is too small, the message will be truncated</para>
		/// <para> this call is not blocking, and will return false if no data is available</para>
		/// </summary>
		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_ReadP2PPacket(CSteamGameServerAPIContext.GetSteamNetworking(), pubDest, cubDest, out pcubMsgSize, out psteamIDRemote, nChannel);
		}

		/// <summary>
		/// <para> AcceptP2PSessionWithUser() should only be called in response to a P2PSessionRequest_t callback</para>
		/// <para> P2PSessionRequest_t will be posted if another user tries to send you a packet that you haven't talked to yet</para>
		/// <para> if you don't want to talk to the user, just ignore the request</para>
		/// <para> if the user continues to send you packets, another P2PSessionRequest_t will be posted periodically</para>
		/// <para> this may be called multiple times for a single user</para>
		/// <para> (if you've called SendP2PPacket() on the other user, this implicitly accepts the session request)</para>
		/// </summary>
		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_AcceptP2PSessionWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		/// <summary>
		/// <para> call CloseP2PSessionWithUser() when you're done talking to a user, will free up resources under-the-hood</para>
		/// <para> if the remote user tries to send data to you again, another P2PSessionRequest_t callback will be posted</para>
		/// </summary>
		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_CloseP2PSessionWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		/// <summary>
		/// <para> call CloseP2PChannelWithUser() when you're done talking to a user on a specific channel. Once all channels</para>
		/// <para> open channels to a user have been closed, the open session to the user will be closed and new data from this</para>
		/// <para> user will trigger a P2PSessionRequest_t callback</para>
		/// </summary>
		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_CloseP2PChannelWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, nChannel);
		}

		/// <summary>
		/// <para> fills out P2PSessionState_t structure with details about the underlying connection to the user</para>
		/// <para> should only needed for debugging purposes</para>
		/// <para> returns false if no connection exists to the specified user</para>
		/// </summary>
		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetP2PSessionState(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, out pConnectionState);
		}

		/// <summary>
		/// <para> Allow P2P connections to fall back to being relayed through the Steam servers if a direct connection</para>
		/// <para> or NAT-traversal cannot be established. Only applies to connections created after setting this value,</para>
		/// <para> or to existing connections that need to automatically reconnect after this value is set.</para>
		/// <para> P2P packet relay is allowed by default</para>
		/// </summary>
		public static bool AllowP2PPacketRelay(bool bAllow) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_AllowP2PPacketRelay(CSteamGameServerAPIContext.GetSteamNetworking(), bAllow);
		}

		/// <summary>
		/// <para>//////////////////////////////////////////////////////////////////////////////////////////</para>
		/// <para> LISTEN / CONNECT connection-oriented interface functions</para>
		/// <para> These functions are more like a client-server TCP API.  One side is the "server"</para>
		/// <para> and "listens" for incoming connections, which then must be "accepted."  The "client"</para>
		/// <para> initiates a connection by "connecting."  Sending and receiving is done through a</para>
		/// <para> connection handle.</para>
		/// <para> For a more UDP-style interface, where you do not track connection handles but</para>
		/// <para> simply send messages to a SteamID, use the UDP-style functions above.</para>
		/// <para> Both methods can send both reliable and unreliable methods.</para>
		/// <para>//////////////////////////////////////////////////////////////////////////////////////////</para>
		/// <para> creates a socket and listens others to connect</para>
		/// <para> will trigger a SocketStatusCallback_t callback on another client connecting</para>
		/// <para> nVirtualP2PPort is the unique ID that the client will connect to, in case you have multiple ports</para>
		/// <para>		this can usually just be 0 unless you want multiple sets of connections</para>
		/// <para> unIP is the local IP address to bind to</para>
		/// <para>		pass in 0 if you just want the default local IP</para>
		/// <para> unPort is the port to use</para>
		/// <para>		pass in 0 if you don't want users to be able to connect via IP/Port, but expect to be always peer-to-peer connections only</para>
		/// </summary>
		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, bool bAllowUseOfPacketRelay) {
			InteropHelp.TestIfAvailableGameServer();
			return (SNetListenSocket_t)NativeMethods.ISteamNetworking_CreateListenSocket(CSteamGameServerAPIContext.GetSteamNetworking(), nVirtualP2PPort, nIP, nPort, bAllowUseOfPacketRelay);
		}

		/// <summary>
		/// <para> creates a socket and begin connection to a remote destination</para>
		/// <para> can connect via a known steamID (client or game server), or directly to an IP</para>
		/// <para> on success will trigger a SocketStatusCallback_t callback</para>
		/// <para> on failure or timeout will trigger a SocketStatusCallback_t callback with a failure code in m_eSNetSocketState</para>
		/// </summary>
		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay) {
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateP2PConnectionSocket(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDTarget, nVirtualPort, nTimeoutSec, bAllowUseOfPacketRelay);
		}

		public static SNetSocket_t CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec) {
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateConnectionSocket(CSteamGameServerAPIContext.GetSteamNetworking(), nIP, nPort, nTimeoutSec);
		}

		/// <summary>
		/// <para> disconnects the connection to the socket, if any, and invalidates the handle</para>
		/// <para> any unread data on the socket will be thrown away</para>
		/// <para> if bNotifyRemoteEnd is set, socket will not be completely destroyed until the remote end acknowledges the disconnect</para>
		/// </summary>
		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_DestroySocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		/// <summary>
		/// <para> destroying a listen socket will automatically kill all the regular sockets generated from it</para>
		/// </summary>
		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_DestroyListenSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		/// <summary>
		/// <para> sending data</para>
		/// <para> must be a handle to a connected socket</para>
		/// <para> data is all sent via UDP, and thus send sizes are limited to 1200 bytes; after this, many routers will start dropping packets</para>
		/// <para> use the reliable flag with caution; although the resend rate is pretty aggressive,</para>
		/// <para> it can still cause stalls in receiving data (like TCP)</para>
		/// </summary>
		public static bool SendDataOnSocket(SNetSocket_t hSocket, byte[] pubData, uint cubData, bool bReliable) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_SendDataOnSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, pubData, cubData, bReliable);
		}

		/// <summary>
		/// <para> receiving data</para>
		/// <para> returns false if there is no data remaining</para>
		/// <para> fills out *pcubMsgSize with the size of the next message, in bytes</para>
		/// </summary>
		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsDataAvailableOnSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, out pcubMsgSize);
		}

		/// <summary>
		/// <para> fills in pubDest with the contents of the message</para>
		/// <para> messages are always complete, of the same size as was sent (i.e. packetized, not streaming)</para>
		/// <para> if *pcubMsgSize &lt; cubDest, only partial data is written</para>
		/// <para> returns false if no data is available</para>
		/// </summary>
		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_RetrieveDataFromSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, pubDest, cubDest, out pcubMsgSize);
		}

		/// <summary>
		/// <para> checks for data from any socket that has been connected off this listen socket</para>
		/// <para> returns false if there is no data remaining</para>
		/// <para> fills out *pcubMsgSize with the size of the next message, in bytes</para>
		/// <para> fills out *phSocket with the socket that data is available on</para>
		/// </summary>
		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsDataAvailable(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, out pcubMsgSize, out phSocket);
		}

		/// <summary>
		/// <para> retrieves data from any socket that has been connected off this listen socket</para>
		/// <para> fills in pubDest with the contents of the message</para>
		/// <para> messages are always complete, of the same size as was sent (i.e. packetized, not streaming)</para>
		/// <para> if *pcubMsgSize &lt; cubDest, only partial data is written</para>
		/// <para> returns false if no data is available</para>
		/// <para> fills out *phSocket with the socket that data is available on</para>
		/// </summary>
		public static bool RetrieveData(SNetListenSocket_t hListenSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_RetrieveData(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, pubDest, cubDest, out pcubMsgSize, out phSocket);
		}

		/// <summary>
		/// <para> returns information about the specified socket, filling out the contents of the pointers</para>
		/// </summary>
		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetSocketInfo(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, out pSteamIDRemote, out peSocketStatus, out punIPRemote, out punPortRemote);
		}

		/// <summary>
		/// <para> returns which local port the listen socket is bound to</para>
		/// <para> *pnIP and *pnPort will be 0 if the socket is set to listen for P2P connections only</para>
		/// </summary>
		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetListenSocketInfo(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, out pnIP, out pnPort);
		}

		/// <summary>
		/// <para> returns true to describe how the socket ended up connecting</para>
		/// </summary>
		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetSocketConnectionType(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket);
		}

		/// <summary>
		/// <para> max packet size, in bytes</para>
		/// </summary>
		public static int GetMaxPacketSize(SNetSocket_t hSocket) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetMaxPacketSize(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket);
		}
	}
}

#endif // !DISABLESTEAMWORKS
