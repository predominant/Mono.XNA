#ifndef __MATRIX_H__
#define __MATRIX_H__


class Matrix
{
private:
	double values[16];
public:
	static Matrix *CreateFromFbx(KFbxMatrix *matrix);
};

#endif