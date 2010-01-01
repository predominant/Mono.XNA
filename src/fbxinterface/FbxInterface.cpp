#include <fbxsdk.h>
#include "Matrix.h"
#include "Item.h"
#include "AnimationChannel.h"
#include "Animation.h"
#include "Node.h"
#include "FbxInterface.h"

KFbxScene *FbxInterface::Import(const char *filename)
{
	manager = KFbxSdkManager::Create();	
		
    int fileFormat = -1;
    if (!manager->GetIOPluginRegistry()->DetectFileFormat(filename, fileFormat))
        fileFormat = manager->GetIOPluginRegistry()->GetNativeReaderFormat();
    
    importer = KFbxImporter::Create(manager, "");
	importer->SetFileFormat(fileFormat);	
	
	if(!importer->Initialize(filename))
	{
		cleanUp();
		return NULL;		
	}				
		
	importOptions = KFbxStreamOptionsFbxReader::Create(manager, "");
	importOptions->SetOption(KFBXSTREAMOPT_FBX_MATERIAL, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_TEXTURE, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_LINK, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_SHAPE, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_GOBO, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_ANIMATION, true);
    importOptions->SetOption(KFBXSTREAMOPT_FBX_GLOBAL_SETTINGS, true);
    
    KFbxScene *scene = KFbxScene::Create(manager, "");	
    
	if(!importer->Import(scene, importOptions))
	{
		cleanUp();
		return NULL;		
	}
		
	cleanUp();	
	return scene;
}

Node *FbxInterface::Traverse(KFbxScene *scene)
{
	return traverseNode(scene->GetRootNode(), NULL);
}

Node *Load(const char *filename)
{
	FbxInterface *fbx = new FbxInterface();
	KFbxScene *scene = fbx->Import(filename);
	if(scene)
		return fbx->Traverse(scene); 
	else
		return NULL;
}

void FbxInterface::cleanUp()
{
	if(importOptions)
		importOptions->Destroy();		
	if(importer)
		importer->Destroy();    
	if(manager)
		manager->Destroy();
}

Node *FbxInterface::traverseNode(KFbxNode *sceneNode, Node *parent)
{
	Node *node = Node::CreateNode("Test", "sourceFilename", "fragmentId", "sourceTool", parent);
	int childCount = sceneNode->GetChildCount();
	node->CreateChildCollection(childCount);
	for(int i=0; i<childCount; i++)
	{
		node->SetChild(i, traverseNode(sceneNode->GetChild(i), node));	
	}
	
	return node;
}