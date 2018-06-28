<template>  
  
    <div class="card">      
    <div class="image">
      <div class="ui dimmer">
        <div class="content">
          <div class="center">
            <div class="ui inverted button">Add Friend</div>
          </div>
        </div>
      </div>
      <img v-on:mouseover="dimOn" v-on:mouseout="dimOff" :src="serie.imageUrl">
    </div>
    <div class="content">
      <div class="header">{{serie.name}}</div>
      <div class="description">
        {{serie.overview | trimString}}
      </div>
    </div>
    <div class="extra content">
      <span class="right floated">
        {{serie.firstAired | formatString}}
      </span>
      <span>
        <i class="user icon"></i>
        {{serie.actors.length}} actors
      </span>
    </div>
    <div v-if="!!serie.actors.length" class="extra content">
        <a v-for="actor in serie.actors.slice(0,5)" :key="actor.id" class="ui basic image label mini">
        <img v-if="actor.imageUrl != 'https://www.thetvdb.com/banners/'" :src="actor.imageUrl" />
        <img v-if="actor.imageUrl == 'https://www.thetvdb.com/banners/'" src="src/assets/jenny.jpg" />{{actor.name}}        
        <div v-if="actor.series.length > 1" class="ui blue circular label mini">{{actor.series.length}}</div>
        </a>        
    </div>
  </div>

</template>

<script>
export default {
  props: ["serie"],
  filters: {
    formatString: function(value) {
      if (!value) return "";
      var d = new Date(value);
      return d.toDateString();
    },
    trimString: function(value) {
      if (!value) return "";
      else if (value.length > 300) return value.substring(0, 299) + "...";
      else return value;
    }
  },
  methods: {
    dimOn: function(event) {
      $(this.$el).dimmer({
        on: "hover"
      });
    },
    dimOff: function(event) {
      //$(this.$el).dimmer('hide');
    }
  }
};
</script>

<style>
.ui.basic.label {
  margin: 2px;
  background-color: #e8e8e8;
}
</style>
