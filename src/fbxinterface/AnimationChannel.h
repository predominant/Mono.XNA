#ifndef __ANIMATIONCHANNEL_H__
#define __ANIMATIONCHANNEL_H__

class AnimationKeyFrame;

class AnimationChannel
{
private:
	const char *name;
	int count;
	AnimationKeyFrame **keyFrames;

public:

	static AnimationChannel *CreateAnimationChannel(const char *name);
	void CreateKeyFrameCollection(int count);	
};

#endif