from django.contrib import admin

from .models import WordRecord, Sound, SoundPair, WordPair


class WordRecordAdmin(admin.ModelAdmin):
    list_display = ['word', 'language', 'description', 'dateCreated', 'dateUpdated', 'publish']

class WordPairAdmin(admin.ModelAdmin):
    list_display = ('get_original', 'get_translation')

    def get_original(self, obj):
        return obj.word
	
    def get_translation(self, obj):
        return obj.word
	
class SoundAdmin(admin.ModelAdmin):
    list_display = ['blob']
	
class SoundPairAdmin(admin.ModelAdmin):
    list_display = ['wordpair', 'sound']

admin.site.register(WordRecord, WordRecordAdmin)
admin.site.register(WordPair, WordPairAdmin)
admin.site.register(Sound, SoundAdmin)
admin.site.register(SoundPair, SoundPairAdmin)
