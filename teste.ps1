cls
Write-Output "Inciando projeto utilizando docker e kubernetes"
Write-Output "Isso pode levar algum tempo..."

Write-Output "Validando se existe o docker na sua maquina..."
$isDockerInstalled = (Get-ItemProperty HKLM:\Software\Microsoft\Windows\CurrentVersion\Uninstall\* | Where { $_.DisplayName -like "Docker*"  }) -ne $null
if(!$isDockerInstalled){
    Write-Output "eh necessario ter o docker instalado, execute o script novamente apos instalar o docker e kubernetes"
    return
}

Write-Output "Validando se existe o kubernetes na sua maquina..."
$commandKubernetes = kubectl cluster-info
$isKubernetesInstalled = ($commandKubernetes -like "*Kubernetes control plane is running*") -ne $null
if(!$isKubernetesInstalled){
    Write-Output notkube
    return
}

Write-Output "Validacoes concluidas."

Write-Output "Iniciando o build da imagem do projeto EsysVendas"
docker build . -t esysvendasimage 2> TempBuild.log

$SEL = Select-String -Path TempBuild.log -Pattern "ERROR: "
if ($SEL -ne $null)
{
    Write-Output "Erro no build, valide no arquivo TempBuild.log na pasta raiz do projeto"
    return
}
rm TempBuild.log
Write-Output "Build concluido com sucesso"

Write-Output "Criando os recursos no kubernetes"
kubectl config set-context --current --namespace=esysvendas-local
kubectl delete all --all
kubectl delete configmap local-configmap

kubectl apply -f kubernetes/properties.local.yml

kubectl apply -f kubernetes/esys-nodeport.yml
kubectl apply -f kubernetes/esysvendasdb-nodeport.yml

kubectl apply -f kubernetes/esysvendasdb-deployment.yml
kubectl apply -f kubernetes/esysvendas-deployment.yml

Write-Output "recursos criados no kubernetes"








