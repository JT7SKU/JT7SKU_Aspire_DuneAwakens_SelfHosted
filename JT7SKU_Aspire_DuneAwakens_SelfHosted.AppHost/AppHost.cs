var rakentaja = DistributedApplication.CreateBuilder(args);

// Ↄ⋃⋂Ⅽ awakening Dyyni herääminen

// Keycloack jotta token hengis, postgress viel mahollisuus battlegroupissa
// Port Forwarding portit 7777-7810 UDP for the game servers. Ja 31982 TCP For RMQ 
var rabbitMq = rakentaja.AddRabbitMQ("viestinta")
    .WithManagementPlugin(port:31982);
var pg = rakentaja.AddPostgres("pg");
var pgDB = pg.AddDatabase("pgdb");


rakentaja.Build().Run();
