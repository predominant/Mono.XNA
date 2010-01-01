#include <fbxsdk.h>
#include "Matrix.h"
#include "AnimationKeyFrame.h"

AnimationKeyFrame *AnimationKeyFrame::CreateAnimationKeyFrame(long time, Matrix *transform)
{
	AnimationKeyFrame *ret = new AnimationKeyFrame();
	ret->time = time;
	ret->transform = transform;
	return ret;
}