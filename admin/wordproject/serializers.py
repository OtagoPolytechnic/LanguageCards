from rest_framework import serializers
from wordproject.models import WordRecord
from wordproject.models import WordPair
from wordproject.models import Sound
from wordproject.models import SoundPair

class WordRecordSerializer(serializers.ModelSerializer):
	class Meta:
		model = WordRecord
		fields = ('word','translation','description','dateCreated','dateUpdated','publish')
		
class WordPairSerializer(serializers.ModelSerializer):
	class Meta:
		model = WordPair
		fields = ('original','translation')
		
class SoundSerializer(serializers.ModelSerializer):
	class Meta:
		model = Sound
		fields = ('blob')
		
class SoundPairSerializer(serializers.ModelSerializer):
	class Meta:
		model = SoundPair
		fields = ('wordpair','sound')