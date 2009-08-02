#include "fbxsdk.h"
#include "Matrix.h"
#include "Item.h"
#include "Animation.h"
#include "Node.h"

Node *Node::CreateNode(const char *name, const char *sourceFilename, const char *fragmentIdentifier, const char *sourceTool, Node *parent)
{
	Node *ret = new Node;
	ret->name = name;
	ret->sourceFilename = sourceFilename;
	ret->sourceTool = sourceTool;
	ret->fragmentIdentifier = fragmentIdentifier;
	ret->parent = parent;
	return ret;
}

void Node::SetTransformation(Matrix *transform)
{
	this->transform = transform;
}

void Node::CreateChildCollection(int count)
{
	numChildren = count;
	*children = new Node[count];
}
	
void Node::SetChild(int index, Node *child)
{
	children[index] = child;
}

void Node::CreateAnimationCollection(int count)
{
	numAnimations = count;
	*animations = new Animation[count];
}

void Node::SetAnimation(int index, Animation *anim)
{
	animations[index] = anim;
}