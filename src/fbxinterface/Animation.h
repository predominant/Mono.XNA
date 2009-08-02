#ifndef __ANIMATION_H__
#define __ANIMATION_H__

class Item;
class AnimationChannel;

class Animation : public Item
{
private:
	long duration;
	AnimationChannel **channels;

public:

	static Animation *CreateAnimation();
	void SetDuration(long duration);
	void CreateChannelCollection(int num);	
};

#endif