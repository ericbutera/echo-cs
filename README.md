# HTTP Echo Server
Simple http server that repeats what it saw.

# Docker
```bash
 docker build -t echo-cs .
 docker run -d -p 8080:80 --name echo-cs aspnetapp
```

Based on [Using Docker Multi Stage Builds to build an ASP.NET Core Echo Server](https://carlos.mendible.com/2018/04/04/using-docker-multi-stage-builds-to-build-an-asp-net-core-echo-server/)