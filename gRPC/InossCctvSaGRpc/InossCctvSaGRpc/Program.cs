using InossCctvSaGRpc;

CctvClient cctvClient = new CctvClient();

cctvClient.GetVersions();
cctvClient.GetAllEquipments();
cctvClient.GetAgentNetworkConfigById();

Console.ReadLine();