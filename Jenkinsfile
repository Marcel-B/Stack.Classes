node ('marcelbenders.de'){
    def mvnHome
    def commitId
    def packageN

    stage('Preparation') { 
        cleanWs()
        checkout scm
        commitId = sh(returnStdout: true, script: 'git rev-parse HEAD')
    }

    try{
        stage('Restore') {
            sh 'dotnet restore  --configfile ./Home.Classes/NuGet.config'
        }
    }catch(Exception ex){
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return 
    }

    try{
        stage('Build'){
            sh 'dotnet build -c Release'
        }
    }catch(Exception ex){
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }

    try{
        stage('Tests') {
            sh 'dotnet test'
        }
    }catch(Exception ex){
        if(env.BRANCH_NAME == 'master'){
            updateGitlabCommitStatus name: 'pack', state: 'canceled', sha: commitId
        }
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }

    try{
        if(env.BRANCH_NAME == 'master'){
            stage('NuGet'){
                withCredentials([string(credentialsId: 'NexusNuGetToken', variable: 'token')]) {
                    mvnHome = env.BUILD_NUMBER
                    packageN = "1.0.${mvnHome}"
                    sh "dotnet pack -p:PackageVersion=${packageN} -c Release -o ./"
                    sh "dotnet nuget push -s https://nexus.qaybe.de/repository/nuget-hosted/ -k ${token} ./*${packageN}.nupkg"
                }
            }   
        }
    }catch(Exception ex){
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }

    try{
        stage('Clean Up'){
            cleanWs()
        }
    }catch(Exception ex){
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }    
}