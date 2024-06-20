ARG PLAYWRIGHT_VERSION=1.44.0

# ---- Build bin ----
FROM mcr.microsoft.com/playwright/dotnet:v${PLAYWRIGHT_VERSION}-jammy AS build

COPY playwright-net-pom.csproj .

RUN dotnet restore

COPY . ./

RUN dotnet build
#publish -c Debug

# ---- Run tests ----
FROM mcr.microsoft.com/playwright/dotnet:v${PLAYWRIGHT_VERSION}-jammy as final

#COPY . /app
COPY --from=build . ./app
#COPY --from=build /bin ./app/bin
#COPY --from=build /obj ./app/obj
#./app/bin/Debug/net8.0
# COPY --from=build /obj ./app/obj

WORKDIR /app

#RUN dotnet test

ENTRYPOINT ["dotnet"]
