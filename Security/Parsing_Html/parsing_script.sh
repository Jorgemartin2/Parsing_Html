#!/bin/bash
if ["$1" == ""];
then
        echo -e "\033[01;33m###############################\033[m"
        echo -e "\033[01;33m#->      PARSING HTML      <- #\033[m"
        echo -e "\033[01;33m###############################\033[m"
        echo "Modo de uso : $0 ADDRESS"
        echo "Exemplo : $0 businesscorp.com.br"
else
        if [ ! -f $1.txt ]; #verifica se o txt existe, se sim, pula o comando, caso contrario executa o WGET
        then
                wget $1 -O $1.txt 2> /dev/null; # -O garante que o arquivo vai ser salvo como o nome do dominio.txt
        fi
        grep href $1.txt | cut -d "/" -f 3 | cut -d '"' -f 1  | grep -v "<l" | grep "\." > lista.$1.txt;
        echo -e "\033[01;33m###############################\033[m"
        echo -e "\033[01;33m#->     BUSCANDO HOSTS      <-#\033[m"
        echo -e "\033[01;33m###############################\033[m"
        cat lista.$1.txt
        echo -e "\033[01;33m###############################\033[m"
        echo -e "\033[01;33m#->    RESOLVENDO HOSTS     <-#\033[m"
        echo -e "\033[01;33m###############################\033[m"
        for url in $(cat lista.$1.txt);
                do
                host $url | grep "has address" # filtra somente pelos endereços que possui endereço IP
                done
rm $1.txt
rm lista.$1.txt
fi