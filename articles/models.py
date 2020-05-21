from django.db import models

# Create your models here.
class Article(models.Model):
    title = CharField(max_length=100),
    slug  = SlugField(),
    body  = TextField(),
    date  = DateField(auto_now_add=True)