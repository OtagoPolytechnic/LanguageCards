from django.contrib import admin

from .models import WordRecord, Sound, SoundPair, WordPair


class WordCustom(admin.StackedInline):
    model = WordPair
    fk_name = 'translation'


class WordRecordAdmin(admin.ModelAdmin):
    inlines = [WordCustom]
    list_display = ['word', 'language', 'description', 'dateCreated', 'dateUpdated', 'publish']
    search_fields = ('word', 'language')


class SoundAdmin(admin.ModelAdmin):
    list_display = ['blob']


class SoundPairAdmin(admin.ModelAdmin):
    list_display = ['wordpair', 'sound']



admin.site.register(WordRecord, WordRecordAdmin)
admin.site.register(Sound, SoundAdmin)
admin.site.register(SoundPair, SoundPairAdmin)
