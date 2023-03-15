### Docker 다운로드 및 설치
https://docs.docker.com/desktop/install/windows-install/

#### Docker를 사용할 준비가 되었는지 확인
docker --version

### Docker 메타데이터 추가
##### Dockerfile 추가 및 편집
fsutil file createnew Dockerfile 0
start Dockerfile

		FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
		WORKDIR /src
		COPY net-core-sample.csproj .
		RUN dotnet restore
		COPY . .
		RUN dotnet publish -c release -o /app

		FROM mcr.microsoft.com/dotnet/aspnet:6.0
		WORKDIR /app
		COPY --from=build /app .
		ENTRYPOINT ["dotnet", "net-core-sample.dll"]

#### .dockerignore 추가 및 편집
fsutil file createnew .dockerignore 0
start .dockerignore

		Dockerfile
		[b|B]in
		[O|o]bj

### Docker 이미지 만들기
docker build -t net-core-sample .

### 이미지 목록 확인
docker images

### 컨테이너에서 앱을 실행
docker run -it --rm -p 80:80 --name net-core-sample net-core-sample

### 명령 프롬프트에서 실행 중인 컨테이너 확인
docker ps

### 사이트 접속
http://localhost/WeatherForecast

### CTRL+C를 눌러 컨테이너에서 서비스를 실행하는 docker run 명령을 종료