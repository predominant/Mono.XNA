#include <fbxsdk.h>

#include "Node.h"
#include "FbxSdkInterface.h"

Node *load(const char *filename)
{
	KFbxSdkManager *manager = KFbxSdkManager::Create();	
		
    int fileFormat = -1;
    if (!manager->GetIOPluginRegistry()->DetectFileFormat(filename, fileFormat))
        fileFormat = manager->GetIOPluginRegistry()->GetNativeReaderFormat();
    
    KFbxImporter *importer = KFbxImporter::Create(manager, "");
	importer->SetFileFormat(fileFormat);	
	
	if(!importer->Initialize(filename))
		return NULL;
		
	KFbxStreamOptionsFbxReader *importOptions = KFbxStreamOptionsFbxReader::Create(manager, "");
	importOptions->SetOption(KFBXSTREAMOPT_FBX_MATERIAL, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_TEXTURE, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_LINK, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_SHAPE, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_GOBO, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_ANIMATION, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_GLOBAL_SETTINGS, true);
    
    KFbxScene *scene = KFbxScene::Create(manager, "");	
	if(!importer->Import(scene, importOptions))
		return NULL;
	
	if(importOptions)
		importOptions->Destroy();
		
	if(importer)
		importer->Destroy();		
    
	if(manager)
		manager->Destroy();
		
	return NULL;	
}