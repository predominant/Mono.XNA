#ifndef __ANIMATIONKEYFRAME_H__
#define __ANIMATIONKEYFRAME_H__

class Matrix;

class AnimationKeyFrame
{
private:
	long time;
	Matrix *transform;

public:

	static AnimationKeyFrame *CreateAnimationKeyFrame(long time, Matrix *transform);	
};

#endif