from django.contrib import admin

from .models import WordRecord, Sound, SoundPair, WordPair


class WordRecordAdmin(admin.ModelAdmin):
    list_display = ['word', 'language', 'description', 'dateCreated', 'dateUpdated', 'publish']
	
class WordPairAdmin(admin.ModelAdmin):
    list_display = ['original', 'translation']
	
class SoundAdmin(admin.ModelAdmin):
    list_display = ['blob']
	
class SoundPairAdmin(admin.ModelAdmin):
    list_display = ['wordpair', 'sound']

admin.site.register(WordRecord, WordRecordAdmin)
admin.site.register(WordPair, WordPairAdmin)
admin.site.register(Sound, SoundAdmin)
admin.site.register(SoundPair, SoundPairAdmin)
