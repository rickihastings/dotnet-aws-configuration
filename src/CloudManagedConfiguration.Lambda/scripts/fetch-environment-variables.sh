#!/bin/bash

set -e

echo "Fetching environment variables from AWS Parameter Store..."

function="${1:-"Function"}";
environment="${2:-"Development"}";
json=$(aws ssm get-parameters-by-path --path "/CloudManagedConfiguration/$environment/" --recursive | jq -r --arg FUNCTION "$function" '.Parameters[] | .Name = (.Name | split("/") | .[3:length] | join("__")) | {($FUNCTION): {(.Name): .Value}}')

mkdir -p temp
echo $json > temp/environment-variables.json

echo "Completed fetch... Delete ./temp or run ./scripts/fetch-environment-variables to re-fetch."
