#ifndef __FBXINTERFACE_H__
#define __FBXINTERFACE_H__

class FbxInterface
{
private:
	KFbxSdkManager *manager;
	KFbxImporter *importer;
	KFbxStreamOptionsFbxReader *importOptions;
	
	void cleanUp();
	Node *traverseNode(KFbxNode *sceneNode, Node *parent);
	
public:
	KFbxScene *Import(const char *filename);
	Node *Traverse(KFbxScene *scene);
	
};

extern "C" Node *Load(const char *fileName);

#endif