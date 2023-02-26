#!/bin/bash

set -e

function="${1:-"Function"}";
environment="${2:-"Development"}";

if [ ! -f temp/environment-variables.json ]
then
  echo "Environment variables not found..."
  
	./scripts/fetch-environment-variables.sh $function $environment
fi

sam build
sam local invoke --event events/event.json --env-vars temp/environment-variables.json $function
