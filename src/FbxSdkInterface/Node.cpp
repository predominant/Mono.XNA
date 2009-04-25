#include <fbxsdk.h>

#include "Node.h"

Node::Node() 
{
	parent = NULL;
	matrix = NULL;
}

Node::~Node()
{
	delete matrix;
}

void setParent(Node *par)
{
	parent = par;
}

void setTransform(KFbxMatrix *trans)
{
	
}

void createChildCollection(int count)
{
	children = new Node[count];
}
	
void setChild(int index, Node *child)
{
	children[index] = child;
}