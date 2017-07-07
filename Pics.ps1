Write-Host "Running script"
 
$token = $env:SYSTEM_ACCESSTOKEN
$TfsLink = $env:SYSTEM_TEAMFOUNDATIONCOLLECTIONURI
Write-Host "TFS: $TfsLink"
 
$TeamProject = $env:SYSTEM_TEAMPROJECT
Write-Host "TeamProject: $TeamProject"
 
$url = "$TfsLink"+"$TeamProject/_apis/"
 
 
$testRuns = Invoke-RestMethod -Uri "$url/test/runs/?api-version=3.0-preview" -Method Get -Headers @{
    Authorization = "Bearer $token"
}

$testRunsIdSorted = $testRuns.value | sort-object id -Descending
 
$mostRecentTestRun = Invoke-RestMethod -Uri "$url/test/runs/$($testRunsIdSorted[0].id)?api-version=3.0-preview" -Method Get -Headers @{
    Authorization = "Bearer $token"
}
 
$mostRecentTestRunUrl = $mostRecentTestRun.url
 
 
$testResultsDirectory = "$env:BUILD_SOURCESDIRECTORY\UnitTestProject1\UnitTestProject1\bin\$env:BuildConfiguration\TestData"
                             
Write-Host "Found directory: $testResultsDirectory"

 
        if($testResultsDirectory)
                                     {
                                     $files = Get-ChildItem -Path "$env:BUILD_SOURCESDIRECTORY\UnitTestProject1\UnitTestProject1\bin\$env:BuildConfiguration\TestData" -Filter *.jpg -Recurse
                                     Write-Host "Found files: $files"
                                     }
 
           
Foreach ($pic IN $files)
 
            {
            $picName = $pic.Name
            $Bytes = Get-Content $pic.FullName -Encoding Byte
            $EncodedText = [System.Convert]::ToBase64String($Bytes)
 
  $JSON = @{
      stream="$EncodedText"
              fileName="$picName"
              comment="test";
              attachmentType="tmiTestRunSummary"
   } | ConvertTo-Json
 
 
$callUrl = "$mostRecentTestRunUrl/attachments?api-version=3.0-preview"
 
            $response2 = Invoke-RestMethod -Uri "$callUrl" -Method Post -Body $JSON -ContentType "application/json" -Headers @{
    Authorization = "Bearer $token"
            }
 
}
 
Write-Host "Posted $callUrl"
 
Write-Host "Removing items from $testResultsDirectory"
Remove-Item "$testResultsDirectory\*"
 
Write-Host "End of script"