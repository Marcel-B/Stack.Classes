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
            sh 'dotnet restore  --configfile NuGet.config'
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
}