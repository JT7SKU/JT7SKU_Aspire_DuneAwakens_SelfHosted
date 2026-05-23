

var rakentaja = DistributedApplication.CreateBuilder(args);

var kubenets = rakentaja.AddKubernetesEnvironment("k8s");
// Ↄ⋃⋂Ⅽ awakening Dyyni herääminen
// tili tokeni  https://account.duneawakening.com/
// Keycloack jotta token hengis, postgress viel mahollisuus battlegroupissa 
// Port Forwarding portit 7777-7810 UDP for the game servers. Ja 31982 TCP For RMQ 
var rabbitMq = rakentaja.AddRabbitMQ("viestinta")
    .WithManagementPlugin(port:31982);
var pg = rakentaja.AddPostgres("pg");
var pgDB = pg.AddDatabase("pgdb");
 
var kayttajanimi = rakentaja.AddParameter("dune");
var avainNaamiointi = rakentaja.AddKeycloak("an").WithPostgres(pgDB);
// steamDB https://steamdb.info/app/4754530/
//var stiimi = rakentaja.AddSteamDB("steamdb"); 


rakentaja.AddProject<Projects.DyyniHeraaminenHallinta>("dyyniheraaminenhallinta");



rakentaja.AddProject<Projects.JT7SKU_Palvelut_SteamService>("jt7sku-palvelut-steamservice");



rakentaja.Build().Run();
