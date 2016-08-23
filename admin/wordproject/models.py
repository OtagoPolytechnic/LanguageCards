from django.db import models
#Change models 23/08/2016

class WordRecord(models.Model):
    word = models.CharField(max_length=100,default='')
    language = models.CharField(max_length=100,default='')
    description = models.TextField(null=True, blank=True, max_length=200)
    dateCreated = models.DateTimeField(auto_now_add=True)
    dateUpdated = models.DateTimeField(auto_now=True)
    publish = models.BooleanField(default=False)
	
class WordPair(models.Model):
	original = models.ForeignKey('WordRecord',on_delete=models.CASCADE,related_name='original')
	translation = models.ForeignKey('WordRecord',on_delete=models.CASCADE,)

class Sound(models.Model):
	blob = models.FileField()

class SoundPair(models.Model):
	wordpair = models.ForeignKey('WordPair',on_delete=models.CASCADE,)
	sound = models.ForeignKey('Sound',on_delete=models.CASCADE,)
	
class Meta:
	ordering=('word',)