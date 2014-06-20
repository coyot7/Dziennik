param($installPath, $toolsPath, $package, $project)

Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

$projects = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection
$msbuild = $projects.GetLoadedProjects($project.FullName) | select-object -First 1
$targetsFile = [System.IO.Path]::Combine($installPath, 'DataObjects.Net.targets')

$projectUri = new-object Uri('file://' + $project.FullName)
$targetUri = new-object Uri('file://' + $targetsFile)
$relativeUri = $projectUri.MakeRelativeUri($targetUri).ToString()
$relativePath = $relativeUri.Replace( `
  [System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

$msbuild.Xml.Properties `
| where-object {$_.Name -eq "XtensiveOrmIntegratedPostSharp"} `
| foreach {$_.Parent.RemoveChild($_)}

$msbuild.Xml.Imports `
| where-object {$_.Project.EndsWith("DataObjects.Net.targets")} `
| foreach {$_.Parent.RemoveChild($_)}

$msbuild.Xml.AddProperty("XtensiveOrmIntegratedPostSharp", "false") | Out-Null
$import = $msbuild.Xml.AddImport($relativePath)
$import.set_Condition("Exists('$relativePath')") | Out-Null

$project.Save()
