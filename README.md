## Minux.io Shell

```
 _ __ ___ (_)_ __  _   ___  __ (_) ___
| '_ ` _ \| | '_ \| | | \ \/ / | |/ _ \
| | | | | | | | | | |_| |>  < _| | (_) |
|_| |_| |_|_|_| |_|\__,_/_/\_(_)_|\___/

```
### Setup instructions for Ubuntu 14.04 (Windows 10)

```
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get update
sudo apt-get install dotnet-dev-1.0.1

```

### Setup instructions for Ubuntu 16.10

```
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ yakkety main" > /etc/apt/sources.list.d/dotnetdev.list'

sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get update

sudo apt-get install dotnet-dev-1.0.1

dotnet restore
dotnet run
```


### Setup instructions for Ubuntu 17.04
```
sudo apt-get install curl libunwind8 gettext
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848826
sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
```
