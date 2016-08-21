from django.http import Http404
from wordproject.models import WordRecord
from rest_framework import status
from rest_framework.response import Response
from wordproject.serializers import WordRecordSerializer
from rest_framework.views import APIView
from rest_framework import generics

class WordRecordList(APIView):
	def get(self, request, format=None):
		wordRecords = WordRecord.objects.all()
		serializer = WordRecordSerializer(wordRecords, many=True)
		return Response(serializer.data)
		
class WordRecordDetail(APIView):
	def get_object(self,pk):
		try:
			return WordRecord.objects.get(pk=pk)
		except WordRecord.DoesNotExist:
			raise Http404
			
	def get(self, request, pk, format=None):
		wordRecord = self.get_object(pk)
		serializer = WordRecordSerializer(wordRecord)
		return Response(serializer.data)
		
class WordRecordFilteredList(generics.ListAPIView):
	serializer_class = WordRecordSerializer
	
	def get_queryset(self):
		"""self.kwargs gets the field from the url"""
		ew = self.kwargs['englishWord']
		return WordRecord.objects.filter(englishWord = ew)
		
class WordRecordQueryParamList(generics.ListAPIView):
	serializer_class = WordRecordSerializer
	
	def get_queryset(self):
		"""pulling terms out from the query parameters"""
		ew = self.request.query_params.get('ew', None)
		return WordRecord.objects.filter(englishWord = ew)