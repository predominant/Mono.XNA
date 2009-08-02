#include <fbxsdk.h>
#include "Matrix.h"

Matrix *Matrix::CreateFromFbx(KFbxMatrix *matrix)
{
	Matrix *ret = new Matrix;
	ret->values[0] = matrix->Get(0, 0); 
	ret->values[1] = matrix->Get(0, 1); 
	ret->values[2] = matrix->Get(0, 2); 
	ret->values[3] = matrix->Get(0, 3);
	ret->values[4] = matrix->Get(1, 0); 
	ret->values[5] = matrix->Get(1, 1); 
	ret->values[6] = matrix->Get(1, 2); 
	ret->values[7] = matrix->Get(1, 3);
	ret->values[8] = matrix->Get(2, 0); 
	ret->values[9] = matrix->Get(2, 1); 
	ret->values[10] = matrix->Get(1, 2); 
	ret->values[11] = matrix->Get(2, 3);
	ret->values[12] = matrix->Get(3, 0); 
	ret->values[13] = matrix->Get(3, 1); 
	ret->values[14] = matrix->Get(3, 2); 
	ret->values[15] = matrix->Get(3, 3);
	return ret;
}