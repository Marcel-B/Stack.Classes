node ('marcelbenders.de'){
    def mvnHome
    def commitId
    def packageN

    properties([gitLabConnection('GitLab')])
    
    stage('Preparation') { 
        cleanWs()
        checkout scm
        commitId = sh(returnStdout: true, script: 'git rev-parse HEAD')
        updateGitlabCommitStatus name: 'restore', state: 'pending', sha: commitId
        updateGitlabCommitStatus name: 'build', state: 'pending', sha: commitId
        updateGitlabCommitStatus name: 'test', state: 'pending', sha: commitId
        if(env.BRANCH_NAME == 'master'){
            updateGitlabCommitStatus name: 'pack', state: 'pending', sha: commitId
        }
        updateGitlabCommitStatus name: 'clean', state: 'pending', sha: commitId
    }

    try{
        stage('Restore') {
            updateGitlabCommitStatus name: 'restore', state: 'running', sha: commitId 
            sh 'dotnet restore  --configfile ./Home.Classes/NuGet.config'
            updateGitlabCommitStatus name: 'restore', state: 'success', sha: commitId 
        }
    }catch(Exception ex){
        updateGitlabCommitStatus name: 'restore', state: 'failed', sha: commitId
        updateGitlabCommitStatus name: 'build', state: 'canceled', sha: commitId
        updateGitlabCommitStatus name: 'test', state: 'canceled', sha: commitId
        if(env.BRANCH_NAME == 'master'){
            updateGitlabCommitStatus name: 'deploy', state: 'canceled', sha: commitId
        }
        updateGitlabCommitStatus name: 'clean', state: 'canceled', sha: commitId
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return 
    }

    try{
        stage('Build'){
            updateGitlabCommitStatus name: 'build', state: 'running', sha: commitId 
            sh 'dotnet build -c Release'
            updateGitlabCommitStatus name: 'build', state: 'success', sha: commitId
        }
    }catch(Exception ex){
        updateGitlabCommitStatus name: 'build', state: 'failed', sha: commitId
        updateGitlabCommitStatus name: 'test', state: 'canceled', sha: commitId
        if(env.BRANCH_NAME == 'master'){
            updateGitlabCommitStatus name: 'pack', state: 'canceled', sha: commitId
        }
        updateGitlabCommitStatus name: 'clean', state: 'canceled', sha: commitId
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }

    try{
        stage('Tests') {
            gitlabCommitStatus("test") {
                sh 'dotnet test'
            }
        }
    }catch(Exception ex){
        updateGitlabCommitStatus name: 'test', state: 'failed', sha: commitId
        if(env.BRANCH_NAME == 'master'){
            updateGitlabCommitStatus name: 'pack', state: 'canceled', sha: commitId
        }
        updateGitlabCommitStatus name: 'clean', state: 'canceled', sha: commitId
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }

        try{
        if(env.BRANCH_NAME == 'master'){
            stage('NuGet'){
                mvnHome = env.BUILD_NUMBER
                packageN = "1.0.${mvnHome}"
                updateGitlabCommitStatus name: 'pack', state: 'running', sha: commitId
                dir('Home.HomeMatic.Domain/'){
                    sh "dotnet pack -p:PackageVersion=${packageN} -c Release -o ./"
                    sh "dotnet nuget push -s https://nexus.qaybe.de/repository/nuget-hosted/ -k f4aa7680-0f0a-3d31-90c4-97e840c221f5 ./*${packageN}.nupkg"
                }
                updateGitlabCommitStatus name: 'pack', state: 'success', sha: commitId
            }   
        }
    }catch(Exception ex){
        updateGitlabCommitStatus name: 'pack', state: 'failed', sha: commitId
        updateGitlabCommitStatus name: 'clean', state: 'canceled', sha: commitId
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }


    try{
        stage('Clean Up'){
            updateGitlabCommitStatus name: 'clean', state: 'running', sha: commitId
            cleanWs()
            updateGitlabCommitStatus name: 'clean', state: 'success', sha: commitId
        }
    }catch(Exception ex){
        updateGitlabCommitStatus name: 'clean', state: 'failed', sha: commitId
        currentBuild.result = 'FAILURE'
        echo "RESULT: ${currentBuild.result}"
        return
    }    

}