#ifndef __NODE_H__
#define __NODE_H__

class Matrix;

class Node
{
private:
	Matrix *transform;
	Node *parent;
	Node *children[];
	
	
public:

	Node();
	~Node();
	
	void setParent(Node *par);
	void setTransform(KFbxMatrix *trans);
	void createChildCollection(int count);
	void setChild(int index, Node *child);		
};

#endif