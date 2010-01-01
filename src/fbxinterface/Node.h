#ifndef __NODE_H__
#define __NODE_H__

class Node : public Item
{
protected:	
	Matrix *transform;
	Node *parent;
	int numChildren;
	Node **children;
	int numAnimations;
	Animation **animations;

public:
		
	static Node *CreateNode(const char *name, const char *sourceFilename, const char *fragmentIdentifier, const char *sourceTool, Node *parent);
	void SetTransformation(Matrix *transform);
	void CreateChildCollection(int count);
	void SetChild(int index, Node *child);
	void CreateAnimationCollection(int count);
	void SetAnimation(int index, Animation *anim);
};

#endif