https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21#connect-to-the-emulator
https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21
https://learn.microsoft.com/en-us/azure/cosmos-db/docker-emulator-linux?tabs=sql-api%2Cssl-netstd21


ipaddr="`ifconfig | grep "inet " | grep -Fv 127.0.0.1 | awk '{print $2}' | head -n 1`"

docker run \
    --publish 8081:8081 \
    --publish 10250-10255:10250-10255 \
    --memory 3g --cpus=4.0 \
    --name=test-linux-emulator \
    --env AZURE_COSMOS_EMULATOR_PARTITION_COUNT=10 \
    --env AZURE_COSMOS_EMULATOR_ENABLE_DATA_PERSISTENCE=true \
    --env AZURE_COSMOS_EMULATOR_IP_ADDRESS_OVERRIDE=$ipaddr \
    --interactive \
    --tty \
    mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator


LOCAL_IP="`ifconfig | grep "inet " | grep -Fv 127.0.0.1 | awk '{print $2}' | head -n 1`"
