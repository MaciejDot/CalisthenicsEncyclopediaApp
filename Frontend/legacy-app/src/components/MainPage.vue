<template>
    <div id="app" ref="app">
      <b-carousel
    :interval="25000"
    controls
      indicators
      background="#ababab"
      img-width="1024"
      img-height="480"
      style="text-shadow: 1px 1px 2px #333;"
  >
    <b-carousel-slide
      class="slide"
      caption="Strength"
      text-html="<b>df</b>"
      img-src="/background.jpg"
    ></b-carousel-slide>
    <b-carousel-slide
      class="slide"
      caption="Second Slide"
      img-src="/background.jpg"
    ></b-carousel-slide>
    <b-carousel-slide
      class="slide"
      caption="Third Slide"
      img-src="/background.jpg"
    ></b-carousel-slide>
    <b-carousel-slide
      class="slide"
      caption="Fourth Slide"
      img-src="/background.jpg"
    ></b-carousel-slide>
  </b-carousel>
  </div>
</template>
<script>
import {BCarousel} from 'bootstrap-vue'
  export default {
    name: 'MainPage',
    components :{
      BCarousel
    }
  }
</script>
<style>
.slide img {
  filter: blur(1.5px);
  transition: filter 1s;
}
.slide img:hover {
  filter: blur(0px);
}
</style>
 