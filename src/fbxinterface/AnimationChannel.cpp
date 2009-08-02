
#include "AnimationKeyFrame.h"
#include "AnimationChannel.h"



AnimationChannel *AnimationChannel::CreateAnimationChannel(const char *name)
{
	AnimationChannel *ret = new AnimationChannel();
	ret->name = name;
}

void AnimationChannel::CreateKeyFrameCollection(int count)
{
	this->count = count;
	*keyFrames = new AnimationKeyFrame[count];
}