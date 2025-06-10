#!/bin/bash

# Name:    MelissaGlobalAddressObjectLinuxDotnet
# Purpose: Use the MelissaUpdater to make the MelissaGlobalAddressObjectLinuxDotnet code usable

######################### Constants ##########################

RED='\033[0;31m' #RED
NC='\033[0m' # No Color

######################### Parameters ##########################

addressLine1=""
addressLine2=""
addressLine3=""
locality=""
administrativeArea=""
postalCode=""
country=""
dataPath=""
license=""
quiet="false"

while [ $# -gt 0 ] ; do
  case $1 in
    --addressLine1) 
        addressLine1="$2"

        if [ "$addressLine1" == "--addressLine2" ] || [ "$addressLine1" == "--addressLine3" ] || [ "$addressLine1" == "--locality" ] || [ "$addressLine1" == "--administrativeArea" ] || [ "$addressLine1" == "--postalCode" ] || [ "$addressLine1" == "--country" ] || [ "$addressLine1" == "--dataPath" ] || [ "$addressLine1" == "--license" ] || [ "$addressLine1" == "--quiet" ] || [ -z "$addressLine1" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'addressLine1\'.${NC}\n"  
            exit 1
        fi  
        ;;
    --addressLine2) 
        addressLine2="$2"

        if [ "$addressLine2" == "--addressLine1" ] || [ "$addressLine2" == "--addressLine3" ] || [ "$addressLine2" == "--locality" ] || [ "$addressLine2" == "--administrativeArea" ] || [ "$addressLine2" == "--postalCode" ] || [ "$addressLine2" == "--country" ] || [ "$addressLine2" == "--dataPath" ] || [ "$addressLine2" == "--license" ] || [ "$addressLine2" == "--quiet" ] || [ -z "$addressLine2" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'addressLine2\'.${NC}\n"  
            exit 1
        fi  
        ;;
    --addressLine3) 
        addressLine3="$2"

        if [ "$addressLine3" == "--addressLine1" ] || [ "$addressLine3" == "--addressLine2" ] || [ "$addressLine3" == "--locality" ] || [ "$addressLine3" == "--administrativeArea" ] || [ "$addressLine3" == "--postalCode" ] || [ "$addressLine3" == "--country" ] || [ "$addressLine3" == "--dataPath" ] || [ "$addressLine3" == "--license" ] || [ "$addressLine3" == "--quiet" ] || [ -z "$addressLine3" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'addressLine3\'.${NC}\n"  
            exit 1
        fi  
        ;;
    --locality) 
        locality="$2"

        if [ "$locality" == "--addressLine1" ] || [ "$locality" == "--addressLine2" ] || [ "$locality" == "--addressLine3" ] || [ "$locality" == "--administrativeArea" ] || [ "$locality" == "--postalCode" ] || [ "$locality" == "--country" ] || [ "$locality" == "--dataPath" ] || [ "$locality" == "--license" ] || [ "$locality" == "--quiet" ] || [ -z "$locality" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'locality\'.${NC}\n"  
            exit 1
        fi  
        ;;
    --administrativeArea) 
        administrativeArea="$2"

        if [ "$administrativeArea" == "--addressLine1" ] || [ "$administrativeArea" == "--addressLine2" ] || [ "$administrativeArea" == "--addressLine3" ] || [ "$administrativeArea" == "--locality" ] || [ "$administrativeArea" == "--postalCode" ] || [ "$administrativeArea" == "--country" ] || [ "$administrativeArea" == "--dataPath" ] || [ "$administrativeArea" == "--license" ] || [ "$administrativeArea" == "--quiet" ] || [ -z "$administrativeArea" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'administrativeArea\'.${NC}\n"  
            exit 1
        fi   
        ;;
    --postalCode) 
        postalCode="$2"

        if [ "$postalCode" == "--addressLine1" ] || [ "$postalCode" == "--addressLine2" ] || [ "$postalCode" == "--addressLine3" ] || [ "$postalCode" == "--locality" ] || [ "$postalCode" == "--administrativeArea" ] || [ "$postalCode" == "--country" ] || [ "$postalCode" == "--dataPath" ] || [ "$postalCode" == "--license" ] || [ "$postalCode" == "--quiet" ] || [ -z "$postalCode" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'zip\'.${NC}\n"  
            exit 1
        fi   
        ;;		
    --country) 
        country="$2"

        if [ "$country" == "--addressLine1" ] || [ "$country" == "--addressLine2" ] || [ "$country" == "--addressLine3" ] || [ "$country" == "--locality" ] || [ "$country" == "--administrativeArea" ] || [ "$country" == "--postalCode" ] || [ "$country" == "--dataPath" ] || [ "$country" == "--license" ] || [ "$country" == "--quiet" ] || [ -z "$country" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'country\'.${NC}\n"  
            exit 1
        fi   
        ;;		
    --dataPath) 
        dataPath="$2"

        if [ "$dataPath" == "--addressLine1" ] || [ "$dataPath" == "--addressLine2" ] || [ "$dataPath" == "--addressLine3" ] || [ "$dataPath" == "--locality" ] || [ "$dataPath" == "--administrativeArea" ] || [ "$dataPath" == "--postalCode" ] || [ "$dataPath" == "--license" ] || [ "$dataPath" == "--quiet" ] || [ -z "$dataPath" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'dataPath\'.${NC}\n"  
            exit 1
        fi   
        ;;		
    --license) 
        license="$2"

        if [ "$license" == "--addressLine1" ] || [ "$license" == "--addressLine2" ] || [ "$license" == "--addressLine3" ] || [ "$license" == "--locality" ] || [ "$license" == "--administrativeArea" ] || [ "$license" == "--postalCode" ] || [ "$license" == "--country" ] || [ "$license" == "--dataPath" ] || [ "$license" == "--quiet" ] || [ -z "$license" ];
        then
            printf "${RED}Error: Missing an argument for parameter \'license\'.${NC}\n"  
            exit 1
        fi    
        ;;
    --quiet) 
        quiet="true" 
        ;;
  esac
  shift
done

######################### Config ###########################

RELEASE_VERSION='2025.Q2'
ProductName="GLOBAL_DQ_DATA"

# Uses the location of the .sh file 
CurrentPath=$(pwd)
ProjectPath="$CurrentPath/MelissaGlobalAddressObjectLinuxDotnet"

BuildPath="$ProjectPath/Build"
if [ ! -d "$BuildPath" ];
then
    mkdir "$BuildPath"
fi

if [ -z "$dataPath" ];
then
    DataPath="$ProjectPath/Data"
else
    DataPath=$dataPath
fi

if [ ! -d "$DataPath" ] && [ "$DataPath" == "$ProjectPath/Data" ];
then
    mkdir "$DataPath"
elif [ ! -d "$DataPath" ] && [ "$DataPath" != "$ProjectPath/Data" ];
then
    printf "\nData file path does not exist. Please check that your file path is correct.\n"
    printf "\nAborting program, see above.\n"
    exit 1
fi


# Config variables for download file(s)
Config1_FileName="libmdGlobalAddr.so"
Config1_ReleaseVersion=$RELEASE_VERSION
Config1_OS="LINUX"
Config1_Compiler="GCC48"
Config1_Architecture="64BIT"
Config1_Type="BINARY"

Config2_FileName="libmdAddr.so"
Config2_ReleaseVersion=$RELEASE_VERSION
Config2_OS="LINUX"
Config2_Compiler="GCC48"
Config2_Architecture="64BIT"
Config2_Type="BINARY"

Config3_FileName="libmdGeo.so"
Config3_ReleaseVersion=$RELEASE_VERSION
Config3_OS="LINUX"
Config3_Compiler="GCC48"
Config3_Architecture="64BIT"
Config3_Type="BINARY"

Config4_FileName="libmdRightFielder.so"
Config4_ReleaseVersion=$RELEASE_VERSION
Config4_OS="LINUX"
Config4_Compiler="GCC48"
Config4_Architecture="64BIT"
Config4_Type="BINARY"

Wrapper_FileName="mdGlobalAddr_cSharpCode.cs"
Wrapper_ReleaseVersion=$RELEASE_VERSION
Wrapper_OS="ANY"
Wrapper_Compiler="NET"
Wrapper_Architecture="ANY"
Wrapper_Type="INTERFACE"

# ######################## Functions #########################

DownloadDataFiles()
{
    printf "============================== MELISSA UPDATER ============================\n"
    printf "MELISSA UPDATER IS DOWNLOADING DATA FILE(S)...\n"

    ./MelissaUpdater/MelissaUpdater manifest -p $ProductName -r $RELEASE_VERSION -l $1 -t $DataPath 
    if [ $? -ne 0 ];
    then
        printf "\nCannot run Melissa Updater. Please check your license string!\n"
        exit 1
    fi     

    printf "Melissa Updater finished downloading data file(s)!\n"
}

DownloadSO() 
{
    printf "\nMELISSA UPDATER IS DOWNLOADING SO(S)...\n"
    
    # Check for quiet mode
    if [ $quiet == "true" ];
    then
        ./MelissaUpdater/MelissaUpdater file --filename $Config1_FileName --release_version $Config1_ReleaseVersion --license $1 --os $Config1_OS --compiler $Config1_Compiler --architecture $Config1_Architecture --type $Config1_Type --target_directory $BuildPath &> /dev/null
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config1_FileName!\n"

        ./MelissaUpdater/MelissaUpdater file --filename $Config2_FileName --release_version $Config2_ReleaseVersion --license $1 --os $Config2_OS --compiler $Config2_Compiler --architecture $Config2_Architecture --type $Config2_Type --target_directory $BuildPath &> /dev/null
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config2_FileName!\n"

        ./MelissaUpdater/MelissaUpdater file --filename $Config3_FileName --release_version $Config3_ReleaseVersion --license $1 --os $Config3_OS --compiler $Config3_Compiler --architecture $Config3_Architecture --type $Config3_Type --target_directory $BuildPath &> /dev/null
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config3_FileName!\n"

        ./MelissaUpdater/MelissaUpdater file --filename $Config4_FileName --release_version $Config4_ReleaseVersion --license $1 --os $Config4_OS --compiler $Config4_Compiler --architecture $Config4_Architecture --type $Config4_Type --target_directory $BuildPath &> /dev/null
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config4_FileName!\n"
    else
        ./MelissaUpdater/MelissaUpdater file --filename $Config1_FileName --release_version $Config1_ReleaseVersion --license $1 --os $Config1_OS --compiler $Config1_Compiler --architecture $Config1_Architecture --type $Config1_Type --target_directory $BuildPath 
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config1_FileName!\n"
   
        ./MelissaUpdater/MelissaUpdater file --filename $Config2_FileName --release_version $Config2_ReleaseVersion --license $1 --os $Config2_OS --compiler $Config2_Compiler --architecture $Config2_Architecture --type $Config2_Type --target_directory $BuildPath 
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config2_FileName!\n"

        ./MelissaUpdater/MelissaUpdater file --filename $Config3_FileName --release_version $Config3_ReleaseVersion --license $1 --os $Config3_OS --compiler $Config3_Compiler --architecture $Config3_Architecture --type $Config3_Type --target_directory $BuildPath 
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config3_FileName!\n"

        ./MelissaUpdater/MelissaUpdater file --filename $Config4_FileName --release_version $Config4_ReleaseVersion --license $1 --os $Config4_OS --compiler $Config4_Compiler --architecture $Config4_Architecture --type $Config4_Type --target_directory $BuildPath 
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi

        printf "Melissa Updater finished downloading $Config4_FileName!\n"
    fi
}

DownloadWrapper() 
{
    printf "\nMELISSA UPDATER IS DOWNLOADING WRAPPER(S)...\n"
    
    # Check for quiet mode
    if [ $quiet == "true" ];
    then
        ./MelissaUpdater/MelissaUpdater file --filename $Wrapper_FileName --release_version $Wrapper_ReleaseVersion --license $1 --os $Wrapper_OS --compiler $Wrapper_Compiler --architecture $Wrapper_Architecture --type $Wrapper_Type --target_directory $ProjectPath &> /dev/null
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi
    else
        ./MelissaUpdater/MelissaUpdater file --filename $Wrapper_FileName --release_version $Wrapper_ReleaseVersion --license $1 --os $Wrapper_OS --compiler $Wrapper_Compiler --architecture $Wrapper_Architecture --type $Wrapper_Type --target_directory $ProjectPath 
        if [ $? -ne 0 ];
        then
            printf "\nCannot run Melissa Updater. Please check your license string!\n"
            exit 1
        fi
    fi
    
    printf "Melissa Updater finished downloading $Wrapper_FileName!\n"
}

CheckSOs() 
{
    if [ ! -f $BuildPath/$Config1_FileName ];
    then
        echo "false"
    elif [ ! -f $BuildPath/$Config2_FileName ];
    then    
        echo "false"
    elif [ ! -f $BuildPath/$Config3_FileName ];
    then
        echo "false"
    elif [ ! -f $BuildPath/$Config4_FileName ];
    then
        echo "false"
    else
        echo "true"
    fi
}

########################## Main ############################

printf "\n====================== Melissa Global Address Object ======================\n                        [ .NET | Linux | 64BIT ]\n"

# Get license (either from parameters or user input)
if [ -z "$license" ];
then
  printf "Please enter your license string: "
  read license
fi

# Check for License from Environment Variables 
if [ -z "$license" ];
then
  license=`echo $MD_LICENSE` 
fi

if [ -z "$license" ];
then
  printf "\nLicense String is invalid!\n"
  exit 1
fi

# Get data file path (either from parameters or user input)
if [ "$DataPath" = "$ProjectPath/Data" ]; then
    printf "Please enter your data files path directory if you have already downloaded the release zip.\nOtherwise, the data files will be downloaded using the Melissa Updater (Enter to skip): "
    read dataPathInput

    if [ ! -z "$dataPathInput" ]; then  
        if [ ! -d "$dataPathInput" ]; then  
            printf "\nData file path does not exist. Please check that your file path is correct.\n"
            printf "\nAborting program, see above.\n"
            exit 1
        else
            DataPath=$dataPathInput
        fi
    fi
fi

# Use Melissa Updater to download data file(s) 
# Download data file(s) 
DownloadDataFiles $license # Comment out this line if using own release

# Download SO(s)
DownloadSO $license 

# Download wrapper(s)
DownloadWrapper $license

# Check if all SO(s) have been downloaded. Exit script if missing
printf "\nDouble checking SO file(s) were downloaded...\n"

SOsAreDownloaded=$(CheckSOs)

if [ "$SOsAreDownloaded" == "false" ];
then
    printf "\nMissing data file(s).  Please check that your license string and directory are correct.\n"

    printf "\nAborting program, see above.\n"
    exit 1
fi

printf "\nAll file(s) have been downloaded/updated!\n"

# Start program
# Build project
printf "\n=========================== BUILD PROJECT ==========================\n"

dotnet publish -f="net8.0" -c Release -o $BuildPath MelissaGlobalAddressObjectLinuxDotnet/MelissaGlobalAddressObjectLinuxDotnet.csproj

# Run Project
if [ -z "$addressLine1" ] && [ -z "$addressLine2" ] && [ -z "$addressLine3" ] && [ -z "$locality" ] && [ -z "$administrativeArea" ] && [ -z "$postalCode" ] && [ -z "$country" ];
then
    export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:./MelissaGlobalAddressObjectLinuxDotnet:./MelissaGlobalAddressObjectLinuxDotnet/Build
    dotnet $BuildPath/MelissaGlobalAddressObjectLinuxDotnet.dll --license $license --dataPath $DataPath
else
    export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:./MelissaGlobalAddressObjectLinuxDotnet:./MelissaGlobalAddressObjectLinuxDotnet/Build
    dotnet $BuildPath/MelissaGlobalAddressObjectLinuxDotnet.dll --license $license --dataPath $DataPath --addressLine1 "$addressLine1" --addressLine2 "$addressLine2" --addressLine3 "$addressLine3" --locality "$locality" --administrativeArea "$administrativeArea" --postalCode "$postalCode" --country "$country"
fi
