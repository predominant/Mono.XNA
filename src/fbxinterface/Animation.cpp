#include "fbxsdk.h"
#include "Matrix.h"
#include "Item.h"
#include "AnimationChannel.h"
#include "Animation.h"

Animation *Animation::CreateAnimation()
{
	return new Animation();
}

void Animation::SetDuration(long duration)
{
	this->duration = duration;
}

void Animation::CreateChannelCollection(int num)
{
	*channels = new AnimationChannel[num];
}