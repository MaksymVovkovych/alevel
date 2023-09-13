using MiniGame;

const string GameName = "D:\\dev\\A_LEVEL\\MiniGame\\MiniGame\\logs.json";



var logger = Logger.Instance();

var app = new App(new PlayerService());
app.Start();

var fileService = new FileService(logger.logs);
fileService.WriteLogsIntoFile(GameName);
