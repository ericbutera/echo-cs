# HTTP Echo Server
Simple http server that repeats what it saw.

# Docker
```bash
# build & run the container
docker build -t echo-cs .
docker run -d -p 5000:80 --name echo echo-cs

# try it out with curl
curl -X POST -H 'Content-Type: application/json' -d "{\"key\":\"value\",\"key2\",\"value2\"}" http://localhost:5000/
```

# Run from command-line
This supports self-signed https, which is nicer than the docker version.
```bash
# deps: wsl2 & dotnet core sdk
dotnet restore
dotnet build
dotnet run
```

# Run from vscode
Push f5, hope the `.vscode/lauch.json` still works.

Based on [Using Docker Multi Stage Builds to build an ASP.NET Core Echo Server](https://carlos.mendible.com/2018/04/04/using-docker-multi-stage-builds-to-build-an-asp-net-core-echo-server/)