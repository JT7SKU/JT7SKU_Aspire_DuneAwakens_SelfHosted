

var rakentaja = DistributedApplication.CreateBuilder(args);

// Ↄ⋃⋂Ⅽ awakening Dyyni herääminen
// account tokeni  https://account.duneawakening.com/
// Keycloack jotta token hengis, postgress viel mahollisuus battlegroupissa
// Port Forwarding portit 7777-7810 UDP for the game servers. Ja 31982 TCP For RMQ 
var rabbitMq = rakentaja.AddRabbitMQ("viestinta")
    .WithManagementPlugin(port:31982);
var pg = rakentaja.AddPostgres("pg");
var pgDB = pg.AddDatabase("pgdb");
var avainNaamiointi = rakentaja.AddKeycloak("an").WithPostgres(pgDB);
//var stiimi = rakentaja.AddSteamDB("steamdb");


rakentaja.Build().Run();
